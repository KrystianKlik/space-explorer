using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class odczepianieRakiet : MonoBehaviour {

    public float x;
    public float y;
    public float z;
    public Rigidbody rb;
    bool odczepione = true;
    public FixedJoint FJ;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKey(KeyCode.K) && (odczepione))
        {

            FJ.breakForce = 0;
            if (FJ.breakForce == 0)
            {
                rb.velocity = new Vector3(x, y, z);
                odczepione = false;
                
            }

        }

    }

   

     
    

}
