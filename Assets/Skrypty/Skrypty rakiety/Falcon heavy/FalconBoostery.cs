using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FalconBoostery : MonoBehaviour
{
    public GameObject showEndOfFuel;

    public float odczepienie;

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

    public ConfigurableJoint CFJ;

    bool wcisnietoSpacje = false;
    public bool odczepione = true;
    bool paliwo;
    bool text = false;
    bool hasExploded = false;
    bool odczepionyPrzezAwarie = false;
    public bool zepsuty = false; //to zmienna do misji awaria

    public ParticleSystem PS;

    // Use this for initialization
    void Start()
    {
        odczepione = true;
        PS.Stop();
        paliwo = false;
        timeForFailure = Random.Range(30 , 65);
    }

  
    // Update is called once per frame
    void Update()
    {
        Odczepienie();

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
            if (ilosc > 0 && ciag > 0)
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
            StartCoroutine(Moc());
        }
    }
    IEnumerator Moc()
    {
        yield return new WaitForSeconds(.1f);
        booster.AddRelativeForce(odczepienie, 0, -0.001f, ForceMode.Impulse);
    }

    void Awaria()
    {
        
        if (zepsuty && paliwo)
        {
            timeForFailure -= Time.deltaTime;
            if ((timeForFailure <= 0 || ilosc <20) && odczepione && CFJ != null)
            {
                odczepionyPrzezAwarie = true;
                CFJ.breakForce = 0;
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
        if (ciag == 0) PS.Stop();
        else main.startSpeed = ciag * 500;
    }
}
