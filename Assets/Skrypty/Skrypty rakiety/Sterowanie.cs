using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sterowanie : MonoBehaviour {

    public Rigidbody rb;
    public ConfigurableJoint CFJ;
    public float predkoscObrotu = 20;

	// Use this for initialization
	void Start () {
       
	}

    // Update is called once per frame
    void Update()
    {
        

       if (CFJ != null)
       {
            rb.constraints = RigidbodyConstraints.None;
            float r = Input.GetAxis("Obrot") * predkoscObrotu * Time.deltaTime;  //qe  obrot
            float z = Input.GetAxis("Horizontal") * predkoscObrotu * Time.deltaTime;//ad lewo prawo
            float x = Input.GetAxis("Vertical") * predkoscObrotu * Time.deltaTime;//ws gora dol
            transform.Rotate(x, z, r);
        }

       
    }
}
