using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wybuch : MonoBehaviour
{
    public GameObject explosionEffect;
    public Rigidbody rb;
   
    float predkosc;

     void Update()
    {
        predkosc = rb.velocity.magnitude * 150;
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Planeta") //Pieknie dziala :D
        {

            if (rb != null && predkosc > 100)
            {
                Instantiate(explosionEffect, transform.position, transform.rotation);
                Destroy(rb.gameObject);
            }


        }

    }


}
