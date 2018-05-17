using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PojawianieSieOgranicnzika : MonoBehaviour {

    public GameObject ogr;
    public GameObject text;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        Ogranicznik();
        if(text.activeSelf)
        {
            ogr.SetActive(false);
        }
    }


        public void Ogranicznik()
    {
         if (Input.GetKey(KeyCode.K))
        {
            ogr.SetActive(true);
        }
    }
    
}
