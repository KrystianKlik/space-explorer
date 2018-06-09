using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondStageDemo : MonoBehaviour {

    public GameObject SliderOgranicznik;
    public GameObject showEndOfFuel;
    public GameObject timeChange;

    public Slider sliderOgranicznik;
    public Slider slider;

    public Rigidbody sateliteRb;

    public float ilosc = 140f;
    public ConfigurableJoint CFJ;
    public ConfigurableJoint Satelite;

    public float ogranicznik = 0;

    float timeForIgnition1 = 50;
    float timeForIgnition2 = 90f;
    float timeForIgnition3 = 160f;

    float timeToFirstRotate = 85f;

    public Rigidbody rb;
    public Rigidbody ziemia;
    bool odczepione = false;
    float thrust = 0.0001f;

    float timea = 10;

    float time1 = 20f;
    float time2 = 10f;
    float time3 = 10f;
    float time4 = 20f;

    bool odczepienieSatelity = false;

    public ParticleSystem PS;

     void Update()
    {
        TimeOFF();
    }

    void FixedUpdate()
    {
        Leci();
        Rotate();
    }

    void TimeOFF()
    {
        if (timeForIgnition3 >= 0)
        {
            timeChange.SetActive(false);
        }
        else
            timeChange.SetActive(true);
    }

    void Leci()
    {
        if (CFJ == null && !odczepienieSatelity)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            SliderOgranicznik.SetActive(true);
            sliderOgranicznik.value = ogranicznik;

            timeForIgnition1 -= Time.deltaTime;
            timeForIgnition2 -= Time.deltaTime;
            timeForIgnition3 -= Time.deltaTime;

            time1 -= Time.deltaTime;

            if (PS.startSpeed > 4) PS.startSpeed = 4f;
            if (PS.startSpeed <= .2) PS.startSpeed = .2f;

            if (time1 >= 0)
            {
                if(ogranicznik>=0 && ogranicznik <= 1)
                {
                    ogranicznik += Time.deltaTime/4;
                    PS.startSpeed += ((ogranicznik * Time.deltaTime) * 15);   
                }
            }

            if (timeForIgnition1 <= 0)
            {
                time2 -= Time.deltaTime;
                if (time2 >= 0)
                { 
                    ogranicznik -= Time.deltaTime / 4;
                    PS.startSpeed -= ((ogranicznik * Time.deltaTime) * 15);
                }
            }

            if (timeForIgnition2 <= 0)
            {
                time3 -= Time.deltaTime;
                if(time3 >= 0)
                { 
                    ogranicznik += Time.deltaTime / 4;
                    PS.startSpeed += ((ogranicznik * Time.deltaTime) * 7);
                }
            }
            Debug.Log(time4);
            if (timeForIgnition3 <= 0)
            {
                time4 -= Time.deltaTime;
               
                if (time4 >= 0)
                {
                    ogranicznik -= Time.deltaTime / 4;
                    PS.startSpeed -= ((ogranicznik * Time.deltaTime) * 7);
                }
            }
            if (time4 <= 0 && !odczepienieSatelity)
            {
                SliderOgranicznik.SetActive(false);
                Satelite.breakForce = 0;
                StartCoroutine(Moc());
                odczepienieSatelity = true;
            }

                if (ogranicznik > 0)
            {
                rb.AddRelativeForce(Vector3.forward * thrust * ogranicznik);
                PS.Play();
                ilosc -= Time.deltaTime * ogranicznik;
                slider.value = ilosc;
            }
            else if (ogranicznik <= 0)
            {
                PS.Stop();
            }
        }
    }
    IEnumerator Moc()
    {
        yield return new WaitForSeconds(.1f);
        sateliteRb.AddRelativeForce(0, 0, 0.0001f, ForceMode.Impulse);
    }

    void Rotate()
    {  
        if (CFJ == null)
        {
            timeToFirstRotate -= Time.deltaTime;
           

            if (timeToFirstRotate <= 0)
            {
                timea -= Time.deltaTime;
                if (timea >= 0)
                {
                    transform.Rotate(Vector3.down * Time.deltaTime * 2); 
                    transform.Rotate(Vector3.left * Time.deltaTime * 3);
                }
            }
        }
    }
}
