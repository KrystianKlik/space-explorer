using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OdczepienieOwiewek : MonoBehaviour {

   public Rigidbody owiewka;
   public FixedJoint FJOwiewka;

    public float wystrzal;
    bool odpadla = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.U)&&(!odpadla))
        {
            FJOwiewka.breakForce = 0;
            owiewka.velocity = new Vector3(wystrzal, 0, 0); //owiekwa lewa na plusie prawa na minusie
            odpadla = true;
        }
	}
}
