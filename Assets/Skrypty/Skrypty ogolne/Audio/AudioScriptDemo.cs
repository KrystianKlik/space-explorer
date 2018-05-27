using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScriptDemo : MonoBehaviour {

    public AudioClip RocketStart;
    public AudioSource RocketSource;

    public GameObject MainBooster;

    BoostersDemo Rocket;

    float iloscPaliwa;
    float timeToStart;
    bool fuel = true;
    bool isPlaying = false;
    // Use this for initialization
    void Start()
    {

        Rocket = MainBooster.GetComponent<BoostersDemo>();
        fuel = true;


        RocketSource.clip = RocketStart;
    }

    // Update is called once per frame
    void Update()
    {

        iloscPaliwa = Rocket.ilosc;
        timeToStart = Rocket.timeEngineStart;

        if (iloscPaliwa < 0) fuel = false;

        if (fuel && !isPlaying && timeToStart <=0)
        {
            RocketSource.Play();
            isPlaying = true;
        }
       else if(iloscPaliwa <=0)
        { RocketSource.Stop(); }



    }
}
