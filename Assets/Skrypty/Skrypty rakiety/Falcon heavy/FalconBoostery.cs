using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FalconBoostery : MonoBehaviour
{
    public GameObject showEndOfFuel;



    bool hasExploded = false;
    bool odczepionyPrzezAwarie = false;
    public bool zepsuty = false; //to zmienna do misji 2
    bool wcisnietoSpacje = false;
    public float mocOdczepienia;

    public Button yourButton;

    public Slider slider;
    public Slider _ilosc;
    public Slider _ciag;
    float ciag;
    float ilosc;
    float wysokosc;
    float predkosc;

    float timeForFailure;

    public Rigidbody ziemia;
    public Rigidbody booster;

    // public FixedJoint FJ;
    public ConfigurableJoint CFJ;
    

    public float mass = 1f;
    float masa;

    public bool odczepione = true;
    bool paliwo;

    bool text = false;
   // public GameObject explosionEffect;
   
    public ParticleSystem PS;



    // Use this for initialization
    void Start()
    {
      //  booster.centerOfMass = new Vector3(0f, 0f, -0.1f);

        odczepione = true;
        PS.Stop();
        paliwo = false;
       // booster.isKinematic = true;
        masa = mass;
        timeForFailure = Random.Range(20000, 200000);
        // Debug.Log(time);
  
    }

  
    // Update is called once per frame
    void Update()
    {
        Odczepienie();

        Masa();



        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
  
        Awaria();


    }

    void FixedUpdate()
    {
        Ogien();
       
    }

    public void Ogien()
    {
        
        if (Input.GetButton("Jump") && odczepione)
        {
            if (Input.GetKey(KeyCode.J) && (!odczepionyPrzezAwarie)) paliwo = false; else paliwo = true;
            booster.isKinematic = false;
        }

        if(paliwo && odczepione)
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
            else if (Input.GetKey(KeyCode.J) && ilosc <= 0)
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

        if ((Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.K)) && odczepione)
        {

            if (!odczepionyPrzezAwarie) { CFJ.breakForce = 0; PS.Stop(); }
            odczepione = false;
            booster.constraints = RigidbodyConstraints.None;
          
         
        }
    }


    void Awaria()
    {
        
        if (zepsuty && paliwo)
        {
            timeForFailure -= Time.deltaTime;
                Debug.Log(timeForFailure);    
            

            if ((timeForFailure <= 0 || ilosc <20) && odczepione && CFJ != null)
            {
                odczepionyPrzezAwarie = true;
                CFJ.breakForce = 0;
              //  odczepione = false;
                booster.constraints = RigidbodyConstraints.None;
                PS.Stop();

            }
            if (ilosc > 0 && !odczepione)
            {

                booster.AddRelativeForce(Vector3.forward * ciag * Time.deltaTime);
                ilosc -= Time.deltaTime;
                slider.value = ilosc;
                PS.Play();
            }

            
        }
    }


    void TaskOnClick()
    {
        ciag = _ciag.value;
        ilosc = _ilosc.value;
        slider.maxValue = ilosc;
        slider.value = ilosc;
        var main = PS.main;
        main.startSpeed = ciag / 20;
    }

    void Masa()
    {

        if ((ilosc < 170) && (ilosc > 100)) { masa = 5f; }
        else if ((ilosc < 250) && (ilosc > 200)) { masa = 4f; }
        else if ((ilosc < 200) && (ilosc > 150)) { masa = 3.6f; }
        else if ((ilosc < 150) && (ilosc > 100)) { masa = 3.4f; }
        else if ((ilosc < 100) && (ilosc > 50)) { masa = 3.2f; }
        else if (ilosc <= 50) { masa = 3f; }
        else if (ilosc == 0) { masa = 2.8f; }
        //else Debug.Log("Blad wywalilo w FalconBoosterSrodkowy w masie");
        booster.mass = masa;
    }

  



}
