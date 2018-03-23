﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMotion : MonoBehaviour {

    public Transform orbitingObject;
    public Ellipse orbitPath;

    public Rigidbody planeta;

   [Range(1, 100)]
    public float szybkoscObrotu = 1f;

    [Range(0,1)]
    public float orbitProgress = 0f;
    public float orbitPeriod = 3f;
    public bool orbitActive = true;
    

                
    // Use this for initialization
    void Start () {
             		if(orbitingObject == null)
        {
            orbitActive = false;
            return;
        }
        SetOrbitingObjectPosition();
        StartCoroutine(AnimateOrbit());
	}

    // void Update()
    //{
    //    planeta.transform.Rotate(0, 0, (szybkoscObrotu) * Time.deltaTime);
    //}

    void SetOrbitingObjectPosition()
    {
        Vector2 orbitPos = orbitPath.Evaluate(orbitProgress);
        orbitingObject.localPosition = new Vector3(orbitPos.x, 0, orbitPos.y); // x y x
    }

    IEnumerator AnimateOrbit() 
    {       if(orbitPeriod < 0.1f) {orbitPeriod = 0.1f;}
        float orbitSpeed = 1f / orbitPeriod;
        while(orbitActive)
        {
            orbitProgress += Time.deltaTime * orbitSpeed;
            orbitProgress %= 1f;
            SetOrbitingObjectPosition();
            yield return null;
        }

    }



}
