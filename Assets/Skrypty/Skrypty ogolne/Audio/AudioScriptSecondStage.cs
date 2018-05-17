using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioScriptSecondStage : MonoBehaviour {

    public AudioClip SecondStageStart;
    public AudioSource SecondStageSource;

    public GameObject MainBooster;

    public GameObject SecondStage;
    public GameObject MainBoosterSound;

    float iloscPaliwa;
    float soundOgranicznik;
    float iloscPaliwaWBoosterze;

    FalconBoosterSrodkowy Rocket;
    FalconRakieta Falki;

    bool isPlaying = false;
    bool spaceWasPressed = false;

    // Use this for initialization
    void Start () {
        Falki = SecondStage.GetComponent<FalconRakieta>();
        Rocket = MainBooster.GetComponent<FalconBoosterSrodkowy>();

        SecondStageSource.clip = SecondStageStart;
    }
	
	// Update is called once per frame
	void Update () {
        iloscPaliwa = Falki.ilosc;
        iloscPaliwaWBoosterze = Rocket.ilosc;
        soundOgranicznik = Falki.ogranicznik;

        SecondStageSource.volume = soundOgranicznik / 2;
        if (iloscPaliwa > 0 && !isPlaying && soundOgranicznik > 0)
        {
            SecondStageSource.Play();
          
            isPlaying = true;
        }

        else if(iloscPaliwa <= 0 && soundOgranicznik <= 0)
        {
            SecondStageSource.Stop();
            isPlaying = false;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            spaceWasPressed = true;
        }

        if (iloscPaliwaWBoosterze <= 0 && spaceWasPressed)
        {
         
            
             if(MainBoosterSound != null) MainBoosterSound.SetActive(false);
            
           
        }
	}
}
