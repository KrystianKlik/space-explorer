using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalconBoostery : MonoBehaviour {

  
    public Rigidbody ziemia;
    public Rigidbody booster;
    public FixedJoint FJ;
    public Vector3 miejsceWybuchu;
    [SerializeField]
    private float thrust = 4000f;

    public float force = 100.0f;
    public float radius = 5.0f;
    public float upwardModifier = 0.0f;
    public ForceMode forceMode;


    public bool odczepione = true;

    public ParticleSystem PS;
   
    // Use this for initialization
    void Start()
    {
        booster.drag = 0.1f;
        odczepione = true;
        PS.Stop();
      //  dym.Stop();

    }

    // Update is called once per frame
    void Update()
    {

        Ogien();

        ZwiekszanieSieAtmosfery();
    }

    void FixedUpdate()
    {
        Odczepienie();
    }

    private void Ogien()
    {
        //if (nieOdczepione)
        //  {
        if (Input.GetButton("Jump") && (odczepione))
        {
            booster.AddRelativeForce(Vector3.forward * thrust * Time.deltaTime);
            PS.Play();
          //  dym.Play();
        }
        else
        {
            PS.Stop();
           // dym.Stop();
        }
        //}
    }

    void Odczepienie() //dzieki temu prostemu kodowi boostery sie odczepiaja
    {

        if (Input.GetKey(KeyCode.K) && (odczepione))
        {
            //  rb.AddExplosionForce(10.0f, miejsceWybuchu, 5  .0f, 2.0f );
            FJ.breakForce = 0;
            odczepione = false;

            ////  foreach(Collider col in Physics.OverlapSphere(transform.position, radius))
            // // {
            //      if(GameObject.FindWithTag("Rakieta"))
            //      {
            //      booster.AddExplosionForce(force, transform.position, radius, upwardModifier, forceMode);
            //      }
            // // }
        }
    }

    void ZwiekszanieSieAtmosfery()
    {
        float wysokosc = Vector3.Distance(booster.transform.position, ziemia.transform.position) - 12720;
        // Debug.Log("wysokosc boostera" + wysokosc);
        if (wysokosc <= 1500) booster.drag = 0.1f;
        else if ((wysokosc > 1500) && (wysokosc < 2000)) booster.drag = 0.05f;
        else booster.drag = 0f;
    }
}
