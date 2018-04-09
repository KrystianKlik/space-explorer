using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wskaznikPaliwa : MonoBehaviour {

    public Slider slider;
    float odliczanie;
    public float dlugosc = 20f;

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
        if (Input.GetButton("Jump") && (odliczanie<=40))
        {
            odliczanie -= Time.deltaTime;
            slider.value = odliczanie;
           // Debug.Log("wartosc w boosterze ", slider, " ", odliczanie);
            Debug.Log(slider); Debug.Log(odliczanie);
        }

        else if(Input.GetKey(KeyCode.X))
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
