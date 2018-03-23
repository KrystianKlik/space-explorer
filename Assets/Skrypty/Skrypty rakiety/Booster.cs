using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour {

    public Rigidbody rb;
    public FixedJoint FJ;
    public Vector3 miejsceWybuchu;
    [SerializeField]
    private float thrust = 5000f;

    public bool odczepione = true;


    // Use this for initialization
    void Start () {
        rb.drag = 1;
        odczepione = true;
     
    }
	
	// Update is called once per frame
	void Update () {
        
        Ogien();
        Odczepienie();
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
}
