using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FalconBoosterSrodkowy : MonoBehaviour
{
    public GameObject showEndOfFuel;

    public Slider slider;
    public Slider _ilosc;
    public Slider _ciag;

    public AudioClip RocketStart;
    public AudioSource RocketSource;

    float ciag;
    public float ilosc;
    float wysokosc;

    public Rigidbody ziemia;
    public Rigidbody booster;

    public ConfigurableJoint CFJ;
    public ConfigurableJoint CFJBocznychBoosterow;
    public FixedJoint LaunchPad;

    public Button yourButton;

    public float mass = 1.5f;

    bool paliwo;
    bool leci = false;
    bool odczepione = true;
    bool text = false;

    public ParticleSystem PS;
   
    // Use this for initialization
    void Start()
    {
        odczepione = true;
        leci = false;
        paliwo = false;
        PS.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        Odczepienie();
    
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }   

     void FixedUpdate()
    {
        Ogien();
    }

    void Ogien()
    {
        
        if (Input.GetButton("Jump") && odczepione )
        {
            if(LaunchPad != null) { LaunchPad.breakForce = 0; }
            booster.isKinematic = false;
            paliwo = true;
        }

        if (paliwo && odczepione)
        {
            if (ilosc > 0)
            {
                booster.AddRelativeForce(Vector3.forward * ciag * Time.deltaTime);
                ilosc -= Time.deltaTime;
                slider.value = ilosc;
                PS.Play();
            }

            else if (ilosc <= 0 && !text)
            {
                PS.Stop();
                showEndOfFuel.SetActive(true);
                StartCoroutine(TextDelay(10));
                text = true;
            }
            else if(Input.GetKey(KeyCode.K) && ilosc <=0)
             {
                showEndOfFuel.SetActive(false);
            }
        }

        
    }
  
    IEnumerator TextDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        showEndOfFuel.SetActive(false);
    }

    void Odczepienie() //dzieki temu prostemu kodowi boostery sie odczepiaja
    {
        if (Input.GetKey(KeyCode.K) && (odczepione))
        {
            
            CFJ.breakForce = 0;
            odczepione = false;
            PS.Stop();
            booster.constraints = RigidbodyConstraints.None;
            StartCoroutine(Moc());
        }
    }

    IEnumerator Moc()
    {
        yield return new WaitForSeconds(.1f);
       booster.AddRelativeForce(0, 0, -0.001f, ForceMode.Impulse);
    }

    void TaskOnClick()
    {
        ciag = _ciag.value;
        ilosc = _ilosc.value;
        slider.maxValue = ilosc;
        slider.value = ilosc;
        var main = PS.main;
        if (ciag == 0) PS.Stop();
        else main.startSpeed = ciag * 1100;
    }
}
