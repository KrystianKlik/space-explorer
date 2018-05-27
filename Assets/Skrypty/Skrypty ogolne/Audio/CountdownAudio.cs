using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownAudio : MonoBehaviour {

    public AudioClip CountdownStart;
    public AudioSource CountdownSource;
        

    // Use this for initialization
    void Start () {
        CountdownSource.clip = CountdownStart;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.F1))
        {
            if (Time.timeScale > 0)
            {
                Time.timeScale = 0;
                CountdownSource.Pause();
            }
            else
            {
                Time.timeScale = 1;
                CountdownSource.Play();
            }
        }
    }
}
