using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lander : MonoBehaviour
{
    public Text wyswietlWysokosc;
    public Text wyswietlPredkosc;

    public Slider sliderOgranicznik;
    public Rigidbody rb;
    public Rigidbody ksiezyc;
    float ogranicznik;
    public ParticleSystem PS;
    public float thrust;

    float wysokosc;
    float predkosc;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Wysokosc();
	}

     void FixedUpdate()
    {
        Leci();
    }
    public void Leci()
    {
        //  ilosc -= Time.deltaTime;
        //   slider.value = ilosc;

        
            sliderOgranicznik.value = ogranicznik;

            if (Input.GetKey(KeyCode.LeftShift) && (ogranicznik < 1))
            {

                if (ogranicznik > 1)
                    ogranicznik = 1;
                ogranicznik += Time.deltaTime;
#pragma warning disable CS0618 // Type or member is obsolete
                if (PS.startSpeed > 2) PS.startSpeed = 2f;
                PS.startSpeed += (ogranicznik * Time.deltaTime) * 3;
#pragma warning restore CS0618 // Type or member is obsolete

            }

            else if (Input.GetKey(KeyCode.LeftControl) && (ogranicznik > 0))
            {
                ogranicznik -= Time.deltaTime;
                if (ogranicznik < 0)
                    ogranicznik = 0;
                if (PS.startSpeed < 0.05f) PS.startSpeed = 0.05f;
#pragma warning disable CS0618 // Type or member is obsolete
                PS.startSpeed -= (ogranicznik * Time.deltaTime) * 3;
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

    public void Wysokosc()
    {
        

        Vector3 direction = rb.position - ksiezyc.position;
        //float distance = direction.magnitude;
        wysokosc = Vector3.Distance(rb.transform.position, ksiezyc.transform.position) * 100;
        wysokosc -= 503596;



        if (wysokosc < 600) { predkosc = 0; }
        else predkosc = rb.velocity.magnitude * 150;

     

        
        wyswietlWysokosc.text = "Wysokosc: " + Mathf.RoundToInt(wysokosc / 1000).ToString() + "km";
        wyswietlPredkosc.text = "Predkosc: " + Mathf.RoundToInt(predkosc).ToString() + "km/h";
    }


}



