using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Satelita : MonoBehaviour {

    public Text wyswietlwysokosc;
    public Text wyswietlPredkosc;

    public ConfigurableJoint CFJ;
    public ConfigurableJoint OwiewkaLewaCFJ;
    public ConfigurableJoint OwiewkaPrawaCFJ;

    float wysokosc;
     float predkosc;

    bool odczepione;

    public Rigidbody rb;
    public Rigidbody ziemia;

    // Use this for initialization
    void Start () {
        odczepione = true;
	}
	
	// Update is called once per frame
	void Update () {
        Wysokosc();
        OdczepienieSatelity();

    }

    public void Wysokosc()
    {
        //  wysokosc = Vector3.Distance(rb.position, ziemia.position);

        Vector3 direction = rb.position - ziemia.position;
        //float distance = direction.magnitude;
        wysokosc = Vector3.Distance(rb.transform.position, ziemia.transform.position) * 150;
         wysokosc -= 3818608 ;
        if (wysokosc < 200) { predkosc = 0; }
        else predkosc = rb.velocity.magnitude * 150;

        //Rigidbody rbToAttract = objToAttract.rb;
        //Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        if (wysokosc < 10000) wyswietlwysokosc.text = "Wysokosc: " + Mathf.RoundToInt(wysokosc).ToString() + "m";
           else wyswietlwysokosc.text = "Wysokosc: " + Mathf.RoundToInt(wysokosc / 1000).ToString() + "km";
           wyswietlPredkosc.text = "Predkosc: " + Mathf.RoundToInt(predkosc).ToString() + "km/h";
    }

     void OdczepienieSatelity()
     {
            if (Input.GetKeyDown(KeyCode.L) && OwiewkaLewaCFJ == null && OwiewkaPrawaCFJ == null && odczepione)
            {
                CFJ.breakForce = 0;
                odczepione = false;
          //  rb.AddRelativeForce(0, 0, 5f, ForceMode.Impulse);
        }
           //if (!odczepione)
           //{
           // float Timer = 2f;
           // Timer -= Time.time;
           // if (Timer <= 0)
                
           // }
    }

}
