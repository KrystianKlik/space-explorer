using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalconBoostery : MonoBehaviour
{
    FalconBoosterSrodkowy falcon;

    public Rigidbody ziemia;
    public Rigidbody booster;
    public FixedJoint FJ;

    [SerializeField]
    private float thrust = 4000f;

    public float dlugosc = 100f;
    float odliczanie;

    public float mass = 1f;
    float masa;

    public bool odczepione = true;
    bool paliwo;

    public ParticleSystem PS;

    // Use this for initialization
    void Start()
    {
        odliczanie = dlugosc;
      
        odczepione = true;
        PS.Stop();
        paliwo = true;
        booster.isKinematic = true;
        masa = mass;
    }

    // Update is called once per frame
    void Update()
    {
        Odczepienie();
        ZwiekszanieSieAtmosfery();
    }

    void FixedUpdate()
    {
      
        Ogien();
    }

    private void Ogien()
    {
        //if (nieOdczepione)
        //  {
        if (Input.GetButton("Jump") && (odczepione) && (paliwo))
        {
            booster.isKinematic = false;
            booster.AddRelativeForce(Vector3.forward * thrust * Time.deltaTime);
            PS.Play();

            odliczanie -= Time.deltaTime;
            if (odliczanie <= 0f)
            { paliwo = false; }

            if (odczepione)
            {
                masa -= Time.deltaTime / 120;
                booster.mass = masa;
            }
        }
        else
        {
            PS.Stop();

        }

    }

    void Odczepienie() //dzieki temu prostemu kodowi boostery sie odczepiaja
    {

        if (Input.GetKey(KeyCode.K) && (odczepione))
        {
          
            FJ.breakForce = 0;
             booster.AddRelativeForce(0, -70f, 0);
             odczepione = false;
        }
    }

    void ZwiekszanieSieAtmosfery()
    {
        float wysokosc = Vector3.Distance(booster.transform.position, ziemia.transform.position) - 29506;
        wysokosc *= 80;
        if (wysokosc <= 10000) booster.drag = 0.3f;
        else if ((wysokosc > 10000) && (wysokosc <= 15000)) booster.drag = 0.1f;
        else if ((wysokosc > 15000) && (wysokosc <= 20000)) booster.drag = 0.09f;
        else if ((wysokosc > 20000) && (wysokosc <= 25000)) booster.drag = 0.07f;
        else if ((wysokosc > 25000) && (wysokosc <= 30000)) booster.drag = 0.05f;
        else if ((wysokosc > 30000) && (wysokosc <= 40000)) booster.drag = 0.04f;
        else if ((wysokosc > 40000) && (wysokosc <= 50000)) booster.drag = 0.01f;
        else if ((wysokosc > 50000) && (wysokosc <= 400000)) booster.drag = 0.0005f;
        else if (wysokosc > 400000) booster.drag = 0f;
    }


}
