using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FalconRakieta : MonoBehaviour {

    public Slider sliderOgranicznik;
    public Slider _ilosc;
    public Slider slider;
    public Button yourButton;

    float ilosc;

    public ConfigurableJoint CFJ;
    public float centrumMasy = .55f;
    public Rigidbody rb;
    public Rigidbody ziemia;
    [SerializeField]

    bool odczepione = false;

    public ParticleSystem PS;
    public float thrust;


    //public FixedJoint FJ; 

    private float wysokosc;
    private float predkosc;

    float bodyLenght;

    [SerializeField]
    private float ogranicznik;


    //bool zrobione = true;
    //cwałująca Valkiria 
    //odyseja kosmiczna

    void Start()
    {
      
       
        PS.Stop();
       
       
    }
        
    void Update()
    {
       
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        //if(Input.GetKey(KeyCode.L))
        //{
        //    rb.AddRelativeForce(0, 0, -5f, ForceMode.Impulse);
        //}
    }

    void FixedUpdate()
    {
        Leci();
    }

    public void Leci()
    {
      //  ilosc -= Time.deltaTime;
     //   slider.value = ilosc;

        if (CFJ)
        { odczepione = true; }
           
       else if(odczepione)
        {
            sliderOgranicznik.value = ogranicznik;

            if (Input.GetKey(KeyCode.LeftShift) && (ogranicznik < 1))
            {
               
                if (ogranicznik > 1)
                    ogranicznik = 1;
                ogranicznik += Time.deltaTime;
#pragma warning disable CS0618 // Type or member is obsolete
                if (PS.startSpeed > 4) PS.startSpeed = 4f;
                PS.startSpeed += (ogranicznik * Time.deltaTime) * 7;
#pragma warning restore CS0618 // Type or member is obsolete

            }

            else if (Input.GetKey(KeyCode.LeftControl) && (ogranicznik > 0))
            {
                ogranicznik -= Time.deltaTime;
                if (ogranicznik < 0)
                    ogranicznik = 0;
                if (PS.startSpeed < 0.2f) PS.startSpeed = 0.2f;
#pragma warning disable CS0618 // Type or member is obsolete
                PS.startSpeed -= (ogranicznik * Time.deltaTime) * 7;
#pragma warning restore CS0618 // Type or member is obsolete

            }

            if (ogranicznik > 0)
                {
                    rb.AddRelativeForce(Vector3.forward * thrust * ogranicznik);
                    PS.Play();
                }
                else if (ogranicznik <= 0)
                {
                    PS.Stop();
                }
        }
    }

  


   void TaskOnClick()
    {
        ilosc = _ilosc.value;
        slider.maxValue = ilosc;
        rb.centerOfMass = new Vector3(0f, 0f, -50f * ogranicznik);
    }



}
