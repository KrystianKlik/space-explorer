using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lander : MonoBehaviour
{

    public Slider sliderOgranicznik;
    public Rigidbody rb;
    float ogranicznik;
    public ParticleSystem PS;
    public float thrust;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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



