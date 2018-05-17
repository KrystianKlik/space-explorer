using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioScript : MonoBehaviour {

    public AudioClip RocketStart;
    public AudioSource RocketSource;

    public GameObject MainBooster;

    FalconBoosterSrodkowy Rocket;

    float iloscPaliwa;
    bool fuel = true;
    bool isPlaying = false;
    // Use this for initialization
    void Start () {

        Rocket = MainBooster.GetComponent<FalconBoosterSrodkowy>();
        fuel = true;


        RocketSource.clip = RocketStart;
	}
	
	// Update is called once per frame
	void Update () {

        iloscPaliwa = Rocket.ilosc;
        
        
        if(iloscPaliwa < 0) fuel = false;

	    if(fuel && Input.GetKey(KeyCode.Space) && !isPlaying)
        {
            RocketSource.Play();
            isPlaying = true;
        }

        if(iloscPaliwa <= 0 || Input.GetKey(KeyCode.K))
        RocketSource.Stop();
	}
}
