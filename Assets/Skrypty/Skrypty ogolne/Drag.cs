using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour {

     float wysokosc;
     float predkosc;

    public Rigidbody rb;
    public Rigidbody ziemia;

    public ParticleSystem tarcie;

    public GameObject explosionEffect;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        wysokosc = Vector3.Distance(rb.transform.position, ziemia.transform.position) * 150;
        wysokosc -= 3818608;
        predkosc = rb.velocity.magnitude * 150;

            
        Atmosfera();
        Tarcie();

    }

    public void Atmosfera()
    {
        if (wysokosc <= 5000) rb.drag = .2f;
        else if ((wysokosc > 5000) && (wysokosc <= 10000)) rb.drag = .2f;
        else if ((wysokosc > 10000) && (wysokosc <= 15000)) rb.drag = .1f;
        else if ((wysokosc > 15000) && (wysokosc <= 20000)) rb.drag = .08f;
        else if ((wysokosc > 20000) && (wysokosc <= 25000)) rb.drag = .05f;
        else if ((wysokosc > 25000) && (wysokosc <= 30000)) rb.drag = .02f;
        else if ((wysokosc > 30000) && (wysokosc <= 40000)) rb.drag = .01f;
        else if ((wysokosc > 40000) && (wysokosc <= 50000)) rb.drag = .0005f;
        else if ((wysokosc > 50000) && (wysokosc <= 400000)) rb.drag = .00005f;
        else if (wysokosc > 400000) rb.drag = 0f;

    }

    public void Tarcie()
    {
      
        if ((wysokosc > 70000) && (wysokosc < 130000) && (predkosc > 5000))
        {
            tarcie.Play();
            if(predkosc > 500000)
            {
                Instantiate(explosionEffect, transform.position, transform.rotation);
                Destroy(rb.gameObject);
            }

        }
        else
            tarcie.Stop();
    }


}
