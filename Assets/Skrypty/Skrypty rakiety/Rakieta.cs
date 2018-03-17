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

    public FixedJoint FJ;
    
    private float odleglosc;
    private float predkosc;

    bool zrobione = true;
    //cwałująca Valkiria 
    //odyseja kosmiczna

    void Start()
    { 
        rb.centerOfMass = centrumMasy;
        PS.Pause();
       
    }

    void Update()
    {
        Sterowanie();
        OdlegloscPredkosc();
    }

     void FixedUpdate()
    {
        Leci();
    }

    void Leci()
    {

        if (Input.GetButton("Jump"))
        {
            if (zrobione)
            {
                FJ.breakForce = 0;
            }
            zrobione = false;

            rb.AddRelativeForce(Vector3.forward * thrust *Time.deltaTime);
            
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

        
        odleglosc = Vector3.Distance(rb.transform.position, ziemia.position) - 6300 ;
   
        predkosc = rb.velocity.magnitude * 16;
       

        wyswietlOdleglosc.text = "Odleglosc: " + Mathf.RoundToInt(odleglosc).ToString() + "m";
        wyswietlPredkosc.text = "Predkosc: " + Mathf.RoundToInt(predkosc).ToString() + "km/h";
    }

    public void Sterowanie()
    {
 
        float z = Input.GetAxis("Horizontal") * predkoscObrotu * Time.deltaTime;
        float x = Input.GetAxis("Vertical") * predkoscObrotu * Time.deltaTime;
        transform.Rotate(0, z, 0);
        transform.Rotate(x, 0, 0);
    }

    


}


