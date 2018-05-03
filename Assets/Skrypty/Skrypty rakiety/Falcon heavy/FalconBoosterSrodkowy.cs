using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FalconBoosterSrodkowy : MonoBehaviour
{ 

    public Text masaCzesci;

    public Vector3 centrumMasy;

    public Slider slider;
    public Slider _ilosc;
    public Slider _ciag;

    float ciag;
    float ilosc;
    float wysokosc;

    public Rigidbody ziemia;
    public Rigidbody booster;

    //public FixedJoint FJ;
    public ConfigurableJoint CFJ;

    public Button yourButton;

    public float mass = 1.5f;
    float masa;
     float dlugosc_do_masy;

    bool paliwo;
    bool leci = false;

    public bool odczepione = true;

    public GameObject explosionEffect;


    public ParticleSystem PS;
   

    // Use this for initialization
    void Start()
    {

        booster.centerOfMass = centrumMasy;
        booster.isKinematic = true;
        odczepione = true;
        leci = false;
        //odliczanie = ilosc;
        paliwo = false;
        masa = mass;
        PS.Stop();

    }

    // Update is called once per frame
    void Update()
    {
       
        Odczepienie();

        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        masaCzesci.text = "Glowny Booster: " + Mathf.RoundToInt(masa*1000).ToString() + "kg";
    
    }   

     void FixedUpdate()
    {
        Ogien();
    }

    void Ogien()
    {
        if (Input.GetButton("Jump") && (odczepione))
        {
            booster.isKinematic = false;
            paliwo = true;
        }

        if (paliwo)
        {
            if (ilosc > 0)
            {
                booster.AddRelativeForce(Vector3.forward * ciag * Time.deltaTime);
                ilosc -= Time.deltaTime;
                slider.value = ilosc;
                PS.Play();
            }

            else if (ilosc <= 0)
            {
                PS.Stop();
                Debug.Log("Skonczylo sie paliwo");
            }
        }

        
    }
  

    //private void Ogien()
    //{
       

    //    if (Input.GetButton("Jump") && (odczepione) && (paliwo))
    //    {
    //        booster.isKinematic = false;
    //        booster.AddRelativeForce(Vector3.forward * ciag * Time.deltaTime);

    //        ilosc -= Time.deltaTime;
    //        slider.value = ilosc;

    //        if ((ilosc <= 0f) || (ciag == 0))
    //        {
    //            paliwo = false;
    //            PS.Stop(); 
    //        }
    //        else PS.Play();

    //        if ((odczepione) && (masa >= .3))
    //        {

    //            //masa -= Time.deltaTime * 100 / (ciag * dlugosc_do_masy);
    //            booster.mass = masa;
    //        }
    //        else mass = .2f;

         

    //    }
    //    else
    //    {
    //        PS.Stop();
    //    }
       
    //}



    void Odczepienie() //dzieki temu prostemu kodowi boostery sie odczepiaja
    {
        if (Input.GetKey(KeyCode.J) && (odczepione))
        {
            CFJ.breakForce = 0;
            odczepione = false;
        }
    }

  


    void TaskOnClick()
    {
        ciag = _ciag.value;
        ilosc = _ilosc.value;
        slider.maxValue = ilosc;

        if (ilosc >= 350) { masa = 3f; }
        else if ((ilosc < 350) && (ilosc > 300)) { masa = 1.9f; }
        else if ((ilosc < 300) && (ilosc > 250)) { masa =  1.8f; }
        else if ((ilosc < 250) && (ilosc > 200)) { masa =  1.7f; }
        else if ((ilosc < 200) && (ilosc > 150)) { masa =  1.6f; }
        else if ((ilosc < 150) && (ilosc > 100)) { masa =  1.5f; }
        else if ((ilosc < 250) && (ilosc > 200)) { masa = 1.4f; }
        else if ((ilosc < 200) && (ilosc > 150)) { masa = 1.3f; }
        else if ((ilosc < 150) && (ilosc > 100)) { masa =  1.2f; }
        else if ((ilosc < 100) && (ilosc > 50)) { masa = 1.1f; }
        else if (ilosc <= 50) { masa = 1f; }
        else if (ilosc == 0) { masa = .8f; }
        else Debug.Log("Blad wywalilo w FalconBoosterSrodkowy w masie");

       // dlugosc_do_masy = ilosc; // ta zmienna to duplikat zmiennej ilosc poniewaz w masie jak dziele przez Time.deltaTime to ona cały czas maleje i pod koniec zaczyna za szybko schodzic masa
    }

   

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Planeta") //Pieknie dziala :D
        {
            
           if(booster != null)
            {
                Instantiate(explosionEffect, transform.position, transform.rotation);
                Destroy(booster.gameObject);
            }
        }
    }
}
