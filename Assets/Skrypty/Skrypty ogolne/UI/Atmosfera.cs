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


        wysokosc = Vector3.Distance(rb.transform.position, ziemia.transform.position) * 150;
        wysokosc -= 3818608;
        // Debug.Log("wysokosc boostera" + wysokosc);



        if (wysokosc <= 5000) { progress = 1f; slider.value = progress; }
        else if ((wysokosc > 5000) && (wysokosc <= 10000)) { progress = .9f; slider.value = progress; }
        else if ((wysokosc > 10000) && (wysokosc <= 15000)) { progress = .8f; slider.value = progress; }
        else if ((wysokosc > 15000) && (wysokosc <= 20000)) { progress = .7f; slider.value = progress; }
        else if ((wysokosc > 20000) && (wysokosc <= 25000)) { progress = .6f; slider.value = progress; }
        else if ((wysokosc > 25000) && (wysokosc <= 30000)) { progress = .5f; slider.value = progress; }
        else if ((wysokosc > 30000) && (wysokosc <= 40000)) { progress = .3f; slider.value = progress; }
        else if ((wysokosc > 40000) && (wysokosc <= 50000)) { progress = .1f; slider.value = progress; }
        else if ((wysokosc > 50000) && (wysokosc <= 400000)) { progress = .05f; slider.value = progress; }
        else if (wysokosc > 400000) { progress = 0; slider.value = progress; }

    }
   
}