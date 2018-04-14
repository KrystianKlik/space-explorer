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
    }
        
    void Update()
    {
        Sterowanie();
        Wysokosc();
     
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

        if (wysokosc <= 10000) rb.drag = 0.3f;
        else if ((wysokosc > 10000) && (wysokosc <= 15000)) rb.drag = 0.1f;
        else if ((wysokosc > 15000) && (wysokosc <= 20000)) rb.drag = 0.09f;
        else if ((wysokosc > 20000) && (wysokosc <= 25000)) rb.drag = 0.08f;
        else if ((wysokosc > 25000) && (wysokosc <= 30000)) rb.drag = 0.05f;
        else if ((wysokosc > 30000) && (wysokosc <= 40000)) rb.drag = 0.04f;
        else if ((wysokosc > 40000) && (wysokosc <= 50000)) rb.drag = 0.01f;
        else if ((wysokosc > 50000) && (wysokosc <= 400000)) rb.drag = 0.0005f;
        else if (wysokosc > 400000) rb.drag = 0f;

        wyswietlwysokosc.text = "wysokosc: " + Mathf.RoundToInt(wysokosc).ToString() + "m";
        wyswietlPredkosc.text = "Predkosc: " + Mathf.RoundToInt(predkosc).ToString() + "km/h";
    }

    public void Sterowanie()
    {
        float r = Input.GetAxis("Obrot") * predkoscObrotu * Time.deltaTime;  //qe  obrot
        float z = Input.GetAxis("Horizontal") * predkoscObrotu * Time.deltaTime;//ad lewo prawo
        float x = Input.GetAxis("Vertical") * predkoscObrotu * Time.deltaTime;//ws gora dol
        transform.Rotate(x, z, r);
    }




}
