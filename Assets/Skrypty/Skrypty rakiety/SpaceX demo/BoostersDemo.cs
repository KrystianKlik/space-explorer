using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostersDemo : MonoBehaviour {

    public Quaternion rotation = Quaternion.identity;

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
  //  float timeToFifthRotate = 170f;

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
    // Use this for initialization
    void Start () {
     
	}
	
	// Update is called once per frame
	void Update () {
       // TimeOFF();
    }

     void FixedUpdate()
    {
        Leci();
        Rotate();
        Odczepienie();

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

            timeTofirstRotate -= Time.fixedDeltaTime;
            timeTosecondRotate -= Time.fixedDeltaTime;
            timeToThirdRotate -= Time.fixedDeltaTime;
            timeToForthRotate -= Time.fixedDeltaTime;
          //  timeToFifthRotate -= Time.fixedDeltaTime;


            if (timeTofirstRotate <= 0)
            {
                time1 -= Time.fixedDeltaTime;
                if (time1 >= 0)
                    transform.Rotate(Vector3.down * Time.fixedDeltaTime * 3); // Rotate the object around its local X axis at 5 degrees per second ZAPAMIETAJ
            }

            if (timeTosecondRotate <= 0)
            {
                time2 -= Time.fixedDeltaTime;
                if (time2 >= 0)
                    transform.Rotate(Vector3.down * Time.fixedDeltaTime * 3);
            }

            if (timeToThirdRotate <= 0)
            {
                time3 -= Time.fixedDeltaTime;
                if (time3 >= 0)
                    transform.Rotate(Vector3.down * Time.fixedDeltaTime * 3);
            }

            if (timeToForthRotate <= 0)
            {
                time4 -= Time.fixedDeltaTime;
                if (time4 >= 0)
                    transform.Rotate(Vector3.down * Time.fixedDeltaTime * 3);
            }

            //if (timeToFifthRotate <= 0)
            //{
            //    time5 -= Time.fixedDeltaTime;
            //    if (time5 >= 0)
            //        transform.Rotate(Vector3.down * Time.fixedDeltaTime * 3);
            //    else if(time5 <= 0)
            //            countdown = false;
            //}
        }

    }

}
