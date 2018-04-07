﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FalconRakieta : MonoBehaviour {

    public Text wyswietlwysokosc;
    public Text wyswietlPredkosc;

    public Vector3 centrumMasy;
    public Rigidbody rb;
    public Rigidbody ziemia;

    public ParticleSystem PS;


    [SerializeField]
    private float thrust = 100f;
    [SerializeField]
    private float predkoscObrotu = 20f;

    //public FixedJoint FJ; 

    private float wysokosc;
    private float predkosc;



    //bool zrobione = true;
    //cwałująca Valkiria 
    //odyseja kosmiczna

    void Start()
    {
        rb.centerOfMass = centrumMasy;
        PS.Stop();
      
        rb.drag = 0.1f;

    }

    void Update()
    {
        Sterowanie();
        Wysokosc();

    }

    void FixedUpdate()
    {
        Leci();
    }

    public void Leci()
    {

        if (Input.GetKey(KeyCode.X))
        {

            //if (zrobione)
            //{
            //    FJ.breakForce = 0;
            //}
            //zrobione = false;

            rb.AddRelativeForce(Vector3.forward * thrust * Time.deltaTime);
              PS.Play();
        }
        else if (!(Input.GetButton("Jump")))
            {
                PS.Stop();

            }
        
    }

   public void Wysokosc()
    {

        //  wysokosc = Vector3.Distance(rb.position, ziemia.position);


        wysokosc = Vector3.Distance(rb.transform.position, ziemia.transform.position) - 12720;
        //  wysokosc = Vector3.ClampMagnitude(rb.transform.position, ziemia.transform.position);
        if (wysokosc < 10) { predkosc = 0; }
        else predkosc = rb.velocity.magnitude * 20;

        if (wysokosc <= 1500) rb.drag = 0.1f;
        else if ((wysokosc > 1500) && (wysokosc < 2000)) rb.drag = 0.05f;
        else rb.drag = 0f;

        wyswietlwysokosc.text = "wysokosc: " + Mathf.RoundToInt(wysokosc).ToString() + "m";
        wyswietlPredkosc.text = "Predkosc: " + Mathf.RoundToInt(predkosc).ToString() + "km/h";
    }

    public void Sterowanie()
    {
        float r = Input.GetAxis("Obrot") * predkoscObrotu * Time.deltaTime;  //qe  obrot
        float z = Input.GetAxis("Horizontal") * predkoscObrotu * Time.deltaTime;//ad lewo prawo
        float x = Input.GetAxis("Vertical") * predkoscObrotu * Time.deltaTime;//ws gora dol
        transform.Rotate(x, z, r);
    }




}