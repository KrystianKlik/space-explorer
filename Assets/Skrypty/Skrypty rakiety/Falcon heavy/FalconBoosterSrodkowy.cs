using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FalconBoosterSrodkowy : MonoBehaviour
{
    public Text masaCzesci;
  

    public Slider slider;
    public Slider _ilosc;
    public Slider _ciag;

    float ciag;
    float ilosc;

    public Rigidbody ziemia;
    public Rigidbody booster;

    public FixedJoint FJ;

    public Button yourButton;

    public float mass = 1.5f;
    float masa;
     float dlugosc_do_masy;

    bool paliwo;

    public bool odczepione = true;

    public ParticleSystem PS;

    // Use this for initialization
    void Start()
    {
       
    
        booster.isKinematic = true;
        odczepione = true;
        //odliczanie = ilosc;
        paliwo = true;

        masa = mass;
       
        
    }








    // Update is called once per frame
    void Update()
    {
        ZwiekszanieSieAtmosfery();
        Odczepienie();

        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        masaCzesci.text = "Glowny Booster: " + Mathf.RoundToInt(masa*1000).ToString() + "kg";
    }

     void FixedUpdate()
    {
        Ogien();
    }

  

    private void Ogien()
    {
       

        if (Input.GetButton("Jump") && (odczepione) && (paliwo))
        {
            booster.isKinematic = false;
            booster.AddRelativeForce(Vector3.forward * ciag * Time.deltaTime);
            PS.Play();

            
            ilosc -= Time.deltaTime;
            slider.value = ilosc;

            

            if (ilosc <= 0f)
            { paliwo = false; }

            if ((odczepione) && (masa >= .3))
            {

                masa -= Time.deltaTime * 100 / (ciag * dlugosc_do_masy);
                booster.mass = masa;
            }
            else mass = .2f;

         

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
        if (wysokosc <= 5000) booster.drag = 1f;
        else if ((wysokosc > 5000) && (wysokosc <= 10000)) booster.drag = 0.9f;
        else if ((wysokosc > 10000) && (wysokosc <= 15000)) booster.drag = 0.8f;
        else if ((wysokosc > 15000) && (wysokosc <= 20000)) booster.drag = 0.7f;
        else if ((wysokosc > 20000) && (wysokosc <= 25000)) booster.drag = 0.5f;
        else if ((wysokosc > 25000) && (wysokosc <= 30000)) booster.drag = 0.3f;
        else if ((wysokosc > 30000) && (wysokosc <= 40000)) booster.drag = 0.2f;
        else if ((wysokosc > 40000) && (wysokosc <= 50000)) booster.drag = 0.01f;
        else if ((wysokosc > 50000) && (wysokosc <= 400000)) booster.drag = 0.00005f;
        else if (wysokosc > 400000) booster.drag = 0f;
    }


    void TaskOnClick()
    {
        ciag = _ciag.value;
        ilosc = _ilosc.value;
        slider.maxValue = ilosc;
        if (ilosc >= 150) { masa = ilosc / 300 ; }
        else if ((ilosc < 150) && (ilosc > 50)) { masa = ilosc / 50; }
        else if (ilosc <= 50) { masa = 1000 + ilosc; }
        dlugosc_do_masy = ilosc; // ta zmienna to duplikat ilosc poniewaz w masie jak dziele przez Time.deltaTime to ona cały czas maleje i kwiatki wychodzą
    }

  

}
