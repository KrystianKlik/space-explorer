using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Atmosfera : MonoBehaviour
{
    
    public Slider slider;
    
    [SerializeField]
    private float wysokosc;
    [SerializeField]
    private float progress = 0f;

    

    public Rigidbody rb;
    public Rigidbody ziemia;

    public void Update()
    {
        Atmo();
    }



    public void Atmo()
    {

        wysokosc = Vector3.Distance(rb.transform.position, ziemia.transform.position) - 29506;
        wysokosc *= 40;
        // Debug.Log("wysokosc boostera" + wysokosc);

        if (wysokosc <= 10000) { progress = 1f; slider.value = progress; } //troposhphere
        else if ((wysokosc > 10000) && (wysokosc <= 30000)) { progress = .8f; slider.value = progress; } //stratosphere
        else if ((wysokosc > 30000) && (wysokosc <= 50000)) { progress = .6f; slider.value = progress; } // mesosphere
        else if ((wysokosc > 50000) && (wysokosc <= 400000)) { progress = .3f; slider.value = progress; } //thermosphere
        else if (wysokosc > 400000) { progress = 0f; slider.value = progress; } //exosphere

         
      
    }
   
}