using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Glosnosc : MonoBehaviour {

    public AudioMixer audioMixer;

    public void UstawGlosnosc(float glosnosc)
    {
        audioMixer.SetFloat("Volume", glosnosc);
    }

}
