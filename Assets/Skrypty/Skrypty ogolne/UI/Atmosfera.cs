using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Atmosfera : MonoBehaviour
{
    
    public Slider slider;
    public float wysokosc;

    public float progress = 1f;

    public Color bialyFill;

    public Rigidbody rb;
    public Rigidbody ziemia;

     void Start()
    {
        slider.value = 1f;
    }

    void Update()
    {
        Atmo();
      
    }

    public void Atmo()
    {

        wysokosc = Vector3.Distance(rb.transform.position, ziemia.transform.position) - 12720;
        // Debug.Log("wysokosc boostera" + wysokosc);

        if (wysokosc <= 1500) { progress = 1f; slider.value = progress; }
        else if ((wysokosc > 1500) && (wysokosc < 2000)) { progress = 0.5f; slider.value = progress; }
        else { progress = 0f; slider.value = progress; }
      
    }

    //float progress = Mathf.Clamp01()
   // Slider.value;
}