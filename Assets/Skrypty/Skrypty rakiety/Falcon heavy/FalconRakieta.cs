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
    public Vector3 centrumMasy;
    public Rigidbody rb;
    public Rigidbody ziemia;
    [SerializeField]

    bool odczepione = false;

    public ParticleSystem PS;


    [SerializeField]
    private float thrust = 100f;
    [SerializeField]
    private float predkoscObrotu = 20f;

    //public FixedJoint FJ; 

    private float wysokosc;
    private float predkosc;


    [SerializeField]
    private float ogranicznik;


    //bool zrobione = true;
    //cwałująca Valkiria 
    //odyseja kosmiczna

    void Start()
    {
        
        rb.centerOfMass = centrumMasy;
        PS.Stop();
       
       
    }
        
    void Update()
    {
        Sterowanie();
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

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

            if (Input.GetKey(KeyCode.LeftShift) && (ogranicznik <= 1))
            {
                ogranicznik += Time.deltaTime;
                if (ogranicznik > 1)
                    ogranicznik = 1;
#pragma warning disable CS0618 // Type or member is obsolete
                PS.startSpeed += ogranicznik/10;
#pragma warning restore CS0618 // Type or member is obsolete

            }

            else if (Input.GetKey(KeyCode.LeftControl) && (ogranicznik >= 0))
            {
                ogranicznik -= Time.deltaTime;
                if (ogranicznik < 0)
                    ogranicznik = 0;
#pragma warning disable CS0618 // Type or member is obsolete
                PS.startSpeed -= ogranicznik/10;
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

  
    public void Sterowanie()
    {
        float r = Input.GetAxis("Obrot") * predkoscObrotu * Time.deltaTime;  //qe  obrot
        float z = Input.GetAxis("Horizontal") * predkoscObrotu * Time.deltaTime;//ad lewo prawo
        float x = Input.GetAxis("Vertical") * predkoscObrotu * Time.deltaTime;//ws gora dol
        transform.Rotate(x, z, r);
    }

   void TaskOnClick()
    {
        ilosc = _ilosc.value;
        slider.maxValue = ilosc;
    }



}
