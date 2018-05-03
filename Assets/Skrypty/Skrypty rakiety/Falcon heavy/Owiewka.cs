using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owiewka : MonoBehaviour {

    public float wystrzal;
    float wysokosc;
    public Rigidbody owiewka;
    public ConfigurableJoint CFJ;

    bool odpadla = false;

   

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        OdczepienieOwiewek();
    }

    void OdczepienieOwiewek()
    {
        if (Input.GetKey(KeyCode.U) && (!odpadla))
        {
          //  FJOwiewka.breakForce = 0;
           // owiewka.velocity= new Vector3(wystrzal, 0, 0); //owiekwa lewa na plusie prawa na minusie
            odpadla = true;
              CFJ.breakForce = 0;
}
    }



}
