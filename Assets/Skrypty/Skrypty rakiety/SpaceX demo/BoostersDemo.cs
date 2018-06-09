using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostersDemo : MonoBehaviour {

    public GameObject showEndOfFuel;
    public GameObject CountdwonSound;

    public ConfigurableJoint CFJ;
    public ConfigurableJoint CFJBocznychBoosterow;

    public FixedJoint LaunchPad;
    public FixedJoint LaunchPadBooster;

    float timeTofirstRotate = 45f;
    float timeTosecondRotate = 100f;
    float timeToThirdRotate =  120f;
    float timeToForthRotate = 130f;

    public ParticleSystem PS;

    public Slider slider;

    public Rigidbody rb;

    public float timeEngineStart = 20f;

    bool paliwo = false;
    bool leci = false;
    bool odczepione = true;
    bool countdown = true;

   public float ilosc = 140f;
    float ciag = 0.0172f;

    float time1 = 3;
    float time2 = 5;
    float time3 = 6;
    float time4 = 8;
    float time5 = 5;
	
	// Update is called once per frame
	void Update () {
        Odczepienie();
    }

     void FixedUpdate()
    {
        Leci();
        Rotate();
   
    }

    void Leci()
    {
        timeEngineStart -= Time.deltaTime;
        if (timeEngineStart <= 0)
        {
            CountdwonSound.SetActive(false);
            leci = true; 
            if(LaunchPad != null && LaunchPadBooster != null)
            {
                LaunchPad.breakForce = 0;
                LaunchPad.breakTorque = 0;
                LaunchPadBooster.breakForce = 0;
                LaunchPadBooster.breakTorque = 0;
            }    
        }
        if (leci && ilosc > 0)
        {
            rb.AddRelativeForce(Vector3.forward * ciag * Time.deltaTime);
            ilosc -= Time.deltaTime;
            slider.value = ilosc;
            PS.Play();
            if (ilosc <= 0) leci = false;
        }
        else if(ilosc <= 0) PS.Stop();
    }
    void Odczepienie()
    {
        if(ilosc <= 0 && odczepione)
        {
            CFJ.breakForce = 0;
            StartCoroutine(Moc());
            odczepione = false;
        }
    }

    IEnumerator Moc()
    {
        yield return new WaitForSeconds(.1f);
        rb.AddRelativeForce(0, 0, -0.003f, ForceMode.Impulse);
    }
    void Rotate()
    {
        if (countdown)
        {
            timeTofirstRotate -= Time.deltaTime;
            timeTosecondRotate -= Time.deltaTime;
            timeToThirdRotate -= Time.deltaTime;
            timeToForthRotate -= Time.deltaTime;

            if (timeTofirstRotate <= 0)
            {
                time1 -= Time.deltaTime;
                if (time1 >= 0)
                    transform.Rotate(Vector3.down * Time.deltaTime * 3);
            }    // Rotate the object around its local X axis at 3 degrees per second 

            if (timeTosecondRotate <= 0)
            {
                time2 -= Time.deltaTime;
                if (time2 >= 0)
                    transform.Rotate(Vector3.down * Time.deltaTime * 3);
            }

            if (timeToThirdRotate <= 0)
            {
                time3 -= Time.deltaTime;
                if (time3 >= 0)
                    transform.Rotate(Vector3.down * Time.deltaTime * 3);
            }

            if (timeToForthRotate <= 0)
            {
                time4 -= Time.deltaTime;
                if (time4 >= 0)
                    transform.Rotate(Vector3.down * Time.deltaTime * 3);
            }
        }
    }
}
