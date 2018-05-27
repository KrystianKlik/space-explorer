using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wskaznikPaliwa : MonoBehaviour {

    public Slider slider;
    float odliczanie;
    public float dlugosc = 20f;
    public GameObject SliderOgranicznik;

	// Use this for initialization
	void Start () {
        odliczanie = dlugosc;
       
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        paliwo();
    }

    void paliwo()
    {
        if (Input.GetButton("Jump") && (odliczanie < 160))
        {
            
            odliczanie -= Time.deltaTime;
            slider.value = odliczanie;
        }

        else if(Input.GetKey(KeyCode.X) && (odliczanie >170) )
        {
            odliczanie -= Time.deltaTime;
            slider.value = odliczanie;  
        }

        else if(odliczanie<0)
        {
            odliczanie = 0;
        }
    }

}
