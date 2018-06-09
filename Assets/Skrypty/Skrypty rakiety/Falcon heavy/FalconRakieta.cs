using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FalconRakieta : MonoBehaviour {

    public Toggle toggle;
    
    public GameObject showEndOfFuel;
    public Slider sliderOgranicznik;
    public Slider _ilosc;
    public Slider slider;
    public Button yourButton;
    
    public float ilosc;
    public ConfigurableJoint CFJ;
  
    public Rigidbody rb;
    public Rigidbody ziemia;

    bool odczepione = false;

    public ParticleSystem PS;
    public float thrust;
    public bool toogleIsOn;

    private float wysokosc;
    private float predkosc;
    public float ogranicznik;
    bool text = false;

    void Start()
    {
        PS.Stop();
    }
        
    void Update()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void FixedUpdate()
    {
        Leci();
    }

    public void Leci()
    {
        if (CFJ)
        { odczepione = true; }
       else if(odczepione && (ilosc >0))
        {
            if (!toogleIsOn)
            {
                ilosc -= Time.deltaTime * ogranicznik / 2;
            }
            slider.value = ilosc;
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
                if (PS.startSpeed < 0.2f)
                {
                    PS.startSpeed = 0.2f;
                }
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

        else if(ilosc <= 0 & !text)
        {
            ogranicznik = 0;
            sliderOgranicznik.value = ogranicznik;
            showEndOfFuel.SetActive(true);
            StartCoroutine(TextDelay(10));
            PS.Stop();
            text = true;
        }
    }

    IEnumerator TextDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        showEndOfFuel.SetActive(false);
    }

    void TaskOnClick()
    {
        ilosc = _ilosc.value;
        slider.maxValue = ilosc;
        slider.value = ilosc;
        rb.centerOfMass = new Vector3(0f, 0f, -1f);
        toogleIsOn = toggle.isOn;
    }
}
