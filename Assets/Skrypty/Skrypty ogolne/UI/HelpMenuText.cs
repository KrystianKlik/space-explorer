using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenuText : MonoBehaviour {


    public GameObject helpText;



	// Use this for initialization
	void Start () {
        StartCoroutine(text(5));
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetKey(KeyCode.F1) || Input.GetKey(KeyCode.Space)))
            helpText.SetActive(false);
    }

    IEnumerator text(float delay)
    {
        yield return new WaitForSeconds(delay);
        helpText.SetActive(false);
    }

}
