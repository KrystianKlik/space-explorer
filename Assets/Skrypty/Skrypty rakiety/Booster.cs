using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour {

    public Rigidbody rb;
    public Rigidbody ziemia;
    public FixedJoint FJ;
    public Vector3 miejsceWybuchu;
    [SerializeField]
    private float thrust = 5000f;

    public bool odczepione = true;


    // Use this for initialization
    void Start () {
        rb.drag = 0.1f;
        odczepione = true;
     
    }
	
	// Update is called once per frame
	void Update () {
        
        Ogien();
        Odczepienie();
        ZwiekszanieSieAtmosfery();
    }

    private void Ogien()
    {
        //if (nieOdczepione)
      //  {
            if (Input.GetKey(KeyCode.X))
            { 
                rb.AddRelativeForce(Vector3.forward * thrust * Time.deltaTime);
            }
        //}
    }

     void Odczepienie() //dzieki temu prostemu kodowi boostery sie odczepiaja
    {
      
            if (Input.GetKey(KeyCode.K)&&(odczepione))
            {
           //  rb.AddExplosionForce(10.0f, miejsceWybuchu, 5  .0f, 2.0f );
                FJ.breakForce = 0;
               odczepione = false;
            }
    }

    void ZwiekszanieSieAtmosfery()
    {
        float wysokosc = Vector3.Distance(rb.transform.position, ziemia.transform.position) - 12720;
       // Debug.Log("wysokosc boostera" + wysokosc);
        if (wysokosc <= 1500) rb.drag = 0.1f;
        else if ((wysokosc >1500) && (wysokosc < 2000))  rb.drag = 0.05f; 
        else rb.drag = 0f;  
    }
}
