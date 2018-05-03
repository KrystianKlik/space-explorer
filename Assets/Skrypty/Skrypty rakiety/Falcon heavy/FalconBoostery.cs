using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FalconBoostery : MonoBehaviour
{
    public Vector3 centrumMasy;

    bool hasExploded = false;

    public float mocOdczepienia;

    public Button yourButton;

    public Slider slider;
    public Slider _ilosc;
    public Slider _ciag;
    float ciag;
    float ilosc;
    float wysokosc;
    float predkosc;

    public Rigidbody ziemia;
    public Rigidbody booster;

    // public FixedJoint FJ;
    public ConfigurableJoint CFJ;

     float dlugosc_do_masy;

    public float mass = 1f;
    float masa;

    public bool odczepione = true;
    bool paliwo;

   // public GameObject explosionEffect;
   
    public ParticleSystem PS;



    // Use this for initialization
    void Start()
    {

        booster.centerOfMass = centrumMasy;
        odczepione = true;
        PS.Stop();
        paliwo = false;
        booster.isKinematic = true;
        masa = mass;

        
    }

    // Update is called once per frame
    void Update()
    {
        Odczepienie();
     

        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        
       

    }

    void FixedUpdate()
    {
        Ogien();
    }

    public void Ogien()
    {

        if (Input.GetButton("Jump") && odczepione)
        {
            if (Input.GetKey(KeyCode.J)) paliwo = false; else paliwo = true;
            booster.isKinematic = false;
        }

        if(paliwo && odczepione)
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
                Debug.Log("Skonczylo sie paliwo w lewym lub prawym boosterze");
            }
        }
     
     

    }

    void Odczepienie() //dzieki temu prostemu kodowi boostery sie odczepiaja
    {

        if (Input.GetKey(KeyCode.K) && (odczepione))
        {
          
             CFJ.breakForce = 0;
            if(CFJ.breakForce == 0)
            {
               // booster.velocity = new Vector3(0, -mocOdczepienia, 0);
                odczepione = false;
            }
          
        }
    }



    void TaskOnClick()
    {
        ciag = _ciag.value;
        ilosc = _ilosc.value;
        slider.maxValue = ilosc;

        if (ilosc >= 350) { masa = 3f; }
        else if ((ilosc < 350) && (ilosc > 300)) { masa =  1.9f; }
        else if ((ilosc < 300) && (ilosc > 250)) { masa = 1.8f; }
        else if ((ilosc < 250) && (ilosc > 200)) { masa = 1.7f; }
        else if ((ilosc < 200) && (ilosc > 150)) { masa =  1.6f; }
        else if ((ilosc < 150) && (ilosc > 100)) { masa =  1.5f; }
        else if ((ilosc < 250) && (ilosc > 200)) { masa = 1.4f; }
        else if ((ilosc < 200) && (ilosc > 150)) { masa = 1.3f; }
        else if ((ilosc < 150) && (ilosc > 100)) { masa =  1.2f; }
        else if ((ilosc < 100) && (ilosc > 50)) { masa = 1.1f; }
        else if (ilosc <= 50) { masa = 1f; }
        else if (ilosc == 0) { masa = .8f; }
        else Debug.Log("Blad wywalilo w FalconBoosterSrodkowy w masie");

        dlugosc_do_masy = ilosc; // ta zmienna to duplikat ilosc poniewaz w masie jak dziele przez Time.deltaTime to ona cały czas maleje i kwiatki wychodzą
    }

  



}
