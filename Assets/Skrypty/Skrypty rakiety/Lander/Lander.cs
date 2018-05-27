using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lander : MonoBehaviour
{
    public Text wyswietlWysokosc;
    public Text wyswietlPredkosc;

    public Toggle toggle;


    public Slider sliderOgranicznik;
    public Rigidbody rb;
    public Rigidbody ksiezyc;
    public Rigidbody ziemia;
    public float ogranicznik;
    public ParticleSystem PS;
    public float thrust;

    public bool toogleIsOn;

    public float ilosc;

    public GameObject showEndOfFuel;

    public Slider _ilosc;
    public Slider slider;

    public Button yourButton;

    float altitude;
    float wysokosc;
    float predkosc;

    bool text = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Wysokosc();

        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

     void FixedUpdate()
    {
        Leci();
    }

    public void Leci()
    {

       
        if (ilosc > 0)
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
                if (PS.startSpeed > 20) PS.startSpeed = 20f;
                PS.startSpeed += (ogranicznik * Time.deltaTime) * 20;
#pragma warning restore CS0618 // Type or member is obsolete

            }

            else if (Input.GetKey(KeyCode.LeftControl) && (ogranicznik > 0))
            {
                ogranicznik -= Time.deltaTime;
                if (ogranicznik < 0)
                    ogranicznik = 0;
                if (PS.startSpeed < 2f) PS.startSpeed = 2f;
#pragma warning disable CS0618 // Type or member is obsolete
                PS.startSpeed -= (ogranicznik * Time.deltaTime) * 20;
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

        else if (ilosc <= 0 & !text)
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

    public void Wysokosc()
    {
        

        Vector3 direction = rb.position - ksiezyc.position;
        //float distance = direction.magnitude;
        wysokosc = Vector3.Distance(rb.transform.position, ksiezyc.transform.position) * 100;
        wysokosc -= 505755.7f;
        altitude = Vector3.Distance(rb.transform.position, ziemia.transform.position) * 100;
        altitude -= 2545000;

        if (wysokosc < 1.169761E+07)
        {
            wyswietlWysokosc.text = "Distance to moon: " + Mathf.RoundToInt(wysokosc / 1000).ToString() + "km";
        }
        else
        {
            wyswietlWysokosc.text = "Distance to earth: " + Mathf.RoundToInt(altitude / 1000).ToString() + "km";
        }

        if(wysokosc < 0) { wysokosc = 0;  predkosc = 0; }


        if (wysokosc < 600) { predkosc = 0; }
        else predkosc = rb.velocity.magnitude * 150;
        wyswietlPredkosc.text = "Speed: " + Mathf.RoundToInt(predkosc).ToString() + "km/h";
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



