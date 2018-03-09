using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObrotPlanety : MonoBehaviour {
    [Range(0,100)]
    public float szybkoscObrotu = 1f;

    // Update is called once per frame
    void Update () {    
        transform.Rotate(0, (szybkoscObrotu/10000) * Time.deltaTime , 0);
    }
}
