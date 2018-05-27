using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanderAudio : MonoBehaviour {

    public AudioClip LanderStart;
    public AudioSource RocketSource;

    public GameObject landerObj;

    Lander lander;

    bool isPlaying = false;

   public float soundOgranicznik;

	// Use this for initialization
	void Start () {
        lander = landerObj.GetComponent<Lander>();

        RocketSource.clip = LanderStart;

    }
	
	// Update is called once per frame
	void Update () {
        soundOgranicznik = lander.ogranicznik;
        RocketSource.volume = soundOgranicznik / 2;

        

        if (soundOgranicznik > 0 && !isPlaying)
        {
            RocketSource.Play();
            isPlaying = true;
        }
        if (soundOgranicznik < 0)
            RocketSource.Stop();

       
	}
}
