using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rakieta : MonoBehaviour {

    public float thrust = 5000f;
    public float srodekMasy = 0.55f;
    public Rigidbody rb;
    float dlugsocStatku = 1;
    [SerializeField]
    float predkoscObrotu = 20f;   
    public Rigidbody ziemia;
    [SerializeField]
    private float odleglosc;

    void Start()
    {
        //tu narazie jest ściernisko
        //  SrodekMasy();
        rb.isKinematic = true;
    }

    void Update()
    {
        Sterowanie();
        odleglosc = Vector3.Distance(rb.position, ziemia.position);
    }

     void FixedUpdate()
    {
        Leci();

    }

    void Leci()
    {
        if (Input.GetButton("Jump"))
        {
            rb.isKinematic = false;
            rb.AddRelativeForce(Vector3.forward * thrust * Time.deltaTime);
            Debug.Log("leci");
            
        }

    }

    public void Sterowanie()
    {
  
        float obrotWertykalny = Input.GetAxis("Horizontal") * predkoscObrotu * Time.deltaTime;
        float obrotHoryzontalny = Input.GetAxis("Vertical") * predkoscObrotu * Time.deltaTime;
        transform.Rotate(0, 0, obrotWertykalny);
        transform.Rotate(0, obrotHoryzontalny, 0);
    }


    //void Srodekmasy()
    //{
    //    rb = getcomponent<rigidbody>();
    //    rb.centerofmass = new vector3(0f, srodekmasy * dlugsocstatku, 0f);
    //}

}


