using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObrotPlanety : MonoBehaviour {
    public float szybkoscObrotu;

    // Update is called once per frame
    void FixedUpdate () {
        transform.Rotate(0, -szybkoscObrotu , 0, Space.World);
    }
}
