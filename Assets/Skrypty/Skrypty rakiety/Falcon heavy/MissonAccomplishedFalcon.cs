using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissonAccomplishedFalcon : MonoBehaviour {

    public GameObject missionAccomplish;
    public Rigidbody rb;
    public Rigidbody ziemia;
    float time;
    bool passed = false;
    float altitude;
    bool clicked = false;
   

    // Use this for initialization
    void Start () {
        time = 3000;
    }
	
	// Update is called once per frame
	void Update () {
        altitude = Vector3.Distance(rb.transform.position, ziemia.transform.position) * 100;
        altitude -= 2545000;

        if(altitude > 100000 && altitude < 6000000)
        {
            time -= Time.deltaTime;
           // Debug.Log(time);
            if (time <= 0) passed = true;
        }
        else
        {
            time = 3000;
        }
        if(passed && !clicked)
        {
            missionAccomplish.SetActive(true);
            Time.timeScale = 0;
            clicked = true;
          
        }
 
    }
}
