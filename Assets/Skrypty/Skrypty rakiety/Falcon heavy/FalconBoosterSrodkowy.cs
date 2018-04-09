﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalconBoosterSrodkowy : MonoBehaviour
{


    public Rigidbody ziemia;
    public Rigidbody booster;
    public FixedJoint FJ;
  
    [SerializeField]
    private float thrust = 4000f;



    float  odliczanie;
    public float dlugosc = 30f;

    bool paliwo;

    public bool odczepione = true;

    public ParticleSystem PS;

    // Use this for initialization
    void Start()
    {
        booster.isKinematic = true;
        booster.drag = 0.1f;
        odczepione = true;
        odliczanie = dlugosc;
        paliwo = true;
    }

    // Update is called once per frame
    void Update()
    {
        ZwiekszanieSieAtmosfery();
    }

     void LateUpdate()
    {
        Ogien();
    }

    void FixedUpdate()
    {
        Odczepienie();
    }

    private void Ogien()
    {
        
        if (Input.GetButton("Jump") && (odczepione) && (paliwo))
        {
            booster.AddRelativeForce(Vector3.forward * thrust * Time.deltaTime);
            PS.Play();
            odliczanie -= Time.deltaTime;
            if (odliczanie <= 0f)
            { paliwo = false; }
            booster.isKinematic = false;
        }
        else
        {
            PS.Stop();
      
        }
       
    }

    void Odczepienie() //dzieki temu prostemu kodowi boostery sie odczepiaja
    {

        if (Input.GetKey(KeyCode.J) && (odczepione))
        {
            //  booster.AddExplosionForce(10.0f, miejsceWybuchu, 5  .0f, 2.0f );
            FJ.breakForce = 0;
            odczepione = false;
            booster.AddRelativeForce(0, 0, -100);
           
        }
    }

   public void ZwiekszanieSieAtmosfery()
    {
        float wysokosc = Vector3.Distance(booster.transform.position, ziemia.transform.position) - 12720;
        wysokosc *= 40;
        if (wysokosc <= 10000) booster.drag = 0.3f;
        else if ((wysokosc > 30000) && (wysokosc <= 50000)) booster.drag = 0.1f;
        else if ((wysokosc > 50000) && (wysokosc <= 400000)) booster.drag = 0.07f;
        else if (wysokosc > 400000) booster.drag = 0f;
    }

}
