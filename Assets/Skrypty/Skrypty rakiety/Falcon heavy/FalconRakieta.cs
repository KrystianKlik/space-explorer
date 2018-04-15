using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FalconRakieta : MonoBehaviour {

    public Text wyswietlwysokosc;
    public Text wyswietlPredkosc;

    public Vector3 centrumMasy;
    public Rigidbody rb;
    public Rigidbody ziemia;

    public ParticleSystem PS;
    public ParticleSystem tarcie;

    [SerializeField]
    private float thrust = 100f;
    [SerializeField]
    private float predkoscObrotu = 20f;

    //public FixedJoint FJ; 

    private float wysokosc;
    private float predkosc;



    //bool zrobione = true;
    //cwałująca Valkiria 
    //odyseja kosmiczna

    void Start()
    {
        
        rb.centerOfMass = centrumMasy;
        PS.Stop();
        rb.drag = 0.1f;
        tarcie.Stop();
    }
        
    void Update()
    {
        Sterowanie();
        Wysokosc();
        Tarcie();
    }

    void LateUpdate()
    {
        Leci();
    }

    public void Leci()
    {

        if (Input.GetKey(KeyCode.X))
        {
            rb.AddRelativeForce(Vector3.forward * thrust * Time.deltaTime);
              PS.Play();
        }
        else if (!(Input.GetButton("Jump")))
            {
                PS.Stop();
            }
        
    }

   public void Wysokosc()
    {

        //  wysokosc = Vector3.Distance(rb.position, ziemia.position);


        wysokosc = Vector3.Distance(rb.transform.position, ziemia.transform.position) -29506  ;
           wysokosc *= 80;
       
        if (wysokosc < 200) { predkosc = 0; }
        else predkosc = rb.velocity.magnitude * 100;

        if (wysokosc <= 5000) rb.drag = 1f;
        else if ((wysokosc > 5000) && (wysokosc <= 10000)) rb.drag = 0.9f;
        else if ((wysokosc > 10000) && (wysokosc <= 15000)) rb.drag = 0.8f;
        else if ((wysokosc > 15000) && (wysokosc <= 20000)) rb.drag = 0.7f;
        else if ((wysokosc > 20000) && (wysokosc <= 25000)) rb.drag = 0.5f;
        else if ((wysokosc > 25000) && (wysokosc <= 30000)) rb.drag = 0.3f;
        else if ((wysokosc > 30000) && (wysokosc <= 40000)) rb.drag = 0.2f;
        else if ((wysokosc > 40000) && (wysokosc <= 50000)) rb.drag = 0.01f;
        else if ((wysokosc > 50000) && (wysokosc <= 400000)) rb.drag = 0.00005f;
        else if (wysokosc > 400000) rb.drag = 0f;

        if (wysokosc < 10000) wyswietlwysokosc.text = "Wysokosc: " + Mathf.RoundToInt(wysokosc).ToString() + "m";
       else wyswietlwysokosc.text = "Wysokosc: " + Mathf.RoundToInt(wysokosc/1000).ToString() + "km";
        wyswietlPredkosc.text = "Predkosc: " + Mathf.RoundToInt(predkosc).ToString() + "km/h";
    }

    public void Sterowanie()
    {
        float r = Input.GetAxis("Obrot") * predkoscObrotu * Time.deltaTime;  //qe  obrot
        float z = Input.GetAxis("Horizontal") * predkoscObrotu * Time.deltaTime;//ad lewo prawo
        float x = Input.GetAxis("Vertical") * predkoscObrotu * Time.deltaTime;//ws gora dol
        transform.Rotate(x, z, r);
    }

    public void Tarcie()
    {
        if ((wysokosc > 80000) && (wysokosc < 120000) && (predkosc > 2000))
        {
            tarcie.Play();
        }
        else
            tarcie.Stop();
    }



}
