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
    [SerializeField]

    bool odczepione = false;

    public ParticleSystem PS;
    public float thrust;
    public bool toogleIsOn;

 

    private float wysokosc;
    private float predkosc;

    float bodyLenght;

    public float ogranicznik;

    public float mass = 1f;
    float masa;
    bool text = false;
    

    //bool zrobione = true;
    //cwałująca Valkiria 
    //odyseja kosmiczna

    void Start()
    {
      
       
        PS.Stop();
        masa = mass;

    }
        
    void Update()
    {
       
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
      //  Masa();
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

    void Masa()
    {
        if (ilosc >= 300) { masa = 5f; }
        else if ((ilosc < 300) && (ilosc > 250)) { masa = 4.8f; }
        else if ((ilosc < 250) && (ilosc > 200)) { masa = 4.4f; }
        else if ((ilosc < 200) && (ilosc > 150)) { masa = 4.2f; }
        else if ((ilosc < 150) && (ilosc > 100)) { masa = 4f; }
        else if ((ilosc < 250) && (ilosc > 200)) { masa = 3.8f; }
        else if ((ilosc < 200) && (ilosc > 150)) { masa = 3.6f; }
        else if ((ilosc < 150) && (ilosc > 100)) { masa = 3.4f; }
        else if ((ilosc < 100) && (ilosc > 50)) { masa = 3.2f; }
        else if (ilosc <= 50) { masa = 3f; }
        else if (ilosc == 0) { masa = 2.8f; }
        //else Debug.Log("Blad wywalilo w FalconBoosterSrodkowy w masie");
        rb.mass = masa;
    }


}
