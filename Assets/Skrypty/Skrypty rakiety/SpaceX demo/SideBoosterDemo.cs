using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideBoosterDemo : MonoBehaviour {

    public Slider slider;
    public float odczepienie;

    public GameObject showEndOfFuel;

    float timeEngineStart = 20f;

    public Rigidbody rb;

    float ciag = 0.04405679f;
   public float ilosc = 120f;

    public ParticleSystem PS;

    public ConfigurableJoint CFJ;

    bool odczepione = true;
    bool leci;

    // Use this for initialization
    void Start () {
     
    }
	
	// Update is called once per frame
	void Update () {
        Leci();
        Odczepienie();
	}

    void Leci()
    {
        timeEngineStart -= Time.deltaTime;
        if (timeEngineStart <= 0)
        {
                leci = true; 
         
               
            }
        if (leci && ilosc > 0)
        {
            rb.AddRelativeForce(Vector3.forward * ciag * Time.deltaTime);
            ilosc -= Time.deltaTime;
            slider.value = ilosc;
            PS.Play();
            
        }
        else if(ilosc <= 0)
        {
            PS.Stop();
            leci = false;
        }
    }

    void Odczepienie()
    {
        if(ilosc <=0 && odczepione)
        {
            CFJ.breakForce = 0;
            StartCoroutine(Moc());
            odczepione = false;
        }
            
    }

    IEnumerator Moc()
    {
        yield return new WaitForSeconds(.1f);
        rb.AddRelativeForce(odczepienie, 0, -0.008f, ForceMode.Impulse);
    }

}
