using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rakieta : MonoBehaviour {

    public Text wyswietlOdleglosc;
    public Text wyswietlPredkosc;

    public Vector3 centrumMasy;

    //public Czas czas;

    public Rigidbody rb;
    public Rigidbody ziemia;

    public ParticleSystem PS;

    [SerializeField]
    private float thrust = 5000f;
    [SerializeField]
    private float predkoscObrotu = 20f;

    
    private float odleglosc;
    private float predkosc;
  

    void Start()
    {
        //tu narazie jest ściernisko
        //  SrodekMasy();
        // rb.isKinematic = true;
        rb.centerOfMass = centrumMasy;
        PS.Pause();
       
    }

    void Update()
    {
        
        Sterowanie();
        OdlegloscPredkosc();
        //czas.PrzyspieszenieCzasu();

    }

     void FixedUpdate()
    {
        Leci();
    
    }

    void Leci()
    {
        if (Input.GetButton("Jump"))  //chciałem dodać że traci masę podszas lotu ale rb.mass nie do końca spełnia moje oczekiwania
        {
            //  rb.isKinematic = false;
            rb.AddRelativeForce(Vector3.forward * thrust * Time.deltaTime);
            Debug.Log("leci");
            PS.Play();
        }
        else if (!(Input.GetButton("Jump")))
        {
            PS.Stop();
        }
    }

    void OdlegloscPredkosc()
    {

        //  odleglosc = Vector3.Distance(rb.position, ziemia.position);

        
        odleglosc = Vector3.Distance(rb.transform.position, ziemia.transform.position) ;
        odleglosc = odleglosc * 1000 - 3011100;
   
        predkosc = rb.velocity.magnitude * 16;
       

        wyswietlOdleglosc.text = "Odleglosc: " + Mathf.RoundToInt(odleglosc).ToString() + "m";
        wyswietlPredkosc.text = "Predkosc: " + Mathf.RoundToInt(predkosc).ToString() + "km/h";
    }

    public void Sterowanie()
    {
  
        float z = Input.GetAxis("Horizontal") * predkoscObrotu * Time.deltaTime;
        float x = Input.GetAxis("Vertical") * predkoscObrotu * Time.deltaTime;
        transform.Rotate(0, 0, z);
        transform.Rotate(x, 0, 0);
    }

    


}


