using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalconBoosterSrodkowy : MonoBehaviour
{


    public Rigidbody ziemia;
    public Rigidbody booster;
    public FixedJoint FJ;

        
    [SerializeField]
    private float thrust = 4000f;

    public float mass = 1.5f;
    float masa;

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
       
        masa = mass;
    }

    // Update is called once per frame
    void Update()
    {
        ZwiekszanieSieAtmosfery();
        Odczepienie();
    }

     void FixedUpdate()
    {
        Ogien();
    }

    

    private void Ogien()
    {
        
        if (Input.GetButton("Jump") && (odczepione) && (paliwo))
        {
            booster.AddRelativeForce(Vector3.forward * thrust * Time.deltaTime);
            PS.Play();
            odliczanie -= Time.deltaTime;
            if(odczepione)
            {
                masa -= Time.deltaTime / 140;
                booster.mass = masa;
            }
         
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
