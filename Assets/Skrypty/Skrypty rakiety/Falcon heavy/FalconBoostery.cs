using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FalconBoostery : MonoBehaviour
{
    public float centrumMasy;

    bool hasExploded = false;
    bool odczepionyPrzezAwarie = false;
    public bool zepsuty = false; //to zmienna do misji 2
    bool wcisnietoSpacje = false;
    public float mocOdczepienia;

    public Button yourButton;

    public Slider slider;
    public Slider _ilosc;
    public Slider _ciag;
    float ciag;
    float ilosc;
    float wysokosc;
    float predkosc;

    float time;

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

        centrumMasy = 20f;
        odczepione = true;
        PS.Stop();
        paliwo = false;
        booster.isKinematic = true;
        masa = mass;
        

    }

     void Awake()
    {
        time = Random.Range(50000, 150000);
    }
    // Update is called once per frame
    void Update()
    {
        Odczepienie();
     

        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        booster.centerOfMass = new Vector3(0f, 0f, -centrumMasy);

        if (time <= 0) { booster.constraints = RigidbodyConstraints.None; }

    }

    void FixedUpdate()
    {
        Ogien();
        Awaria();
    }

    public void Ogien()
    {
        
        if (Input.GetButton("Jump") && odczepione)
        {
            if (Input.GetKey(KeyCode.J) && (!odczepionyPrzezAwarie)) paliwo = false; else paliwo = true;
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

        if ((Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.K)) && odczepione)
        {

            if (!odczepionyPrzezAwarie) { CFJ.breakForce = 0; PS.Stop(); } 
            booster.constraints = RigidbodyConstraints.None;
            odczepione = false;
        }
    }


    void Awaria()
    {if (Input.GetKeyDown(KeyCode.Space)) wcisnietoSpacje = true;
        if (zepsuty && wcisnietoSpacje)
        {
            
            time -= Time.time;
            Debug.Log(time);
            if (time <= 0 && odczepione && CFJ != null)
            {
                odczepionyPrzezAwarie = true;
                CFJ.breakForce = 0;
              //  odczepione = false;
                booster.constraints = RigidbodyConstraints.None;
                PS.Stop();
                booster.AddRelativeForce(20f, 0, 0);
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
        //else Debug.Log("Blad wywalilo w FalconBoosterSrodkowy w masie");

    

      //  dlugosc_do_masy = ilosc; // ta zmienna to duplikat ilosc poniewaz w masie jak dziele przez Time.deltaTime to ona cały czas maleje i kwiatki wychodzą
    }

  



}
