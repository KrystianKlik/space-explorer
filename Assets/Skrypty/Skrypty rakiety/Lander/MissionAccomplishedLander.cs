using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionAccomplishedLander : MonoBehaviour {


    public GameObject missionAccomplish;
    public Rigidbody rb;
    public Rigidbody ziemia;

     float altitude;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        altitude = Vector3.Distance(rb.transform.position, ziemia.transform.position) * 100;
        altitude -= 2545000;

        if(altitude <= 50000)
        {
            missionAccomplish.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
