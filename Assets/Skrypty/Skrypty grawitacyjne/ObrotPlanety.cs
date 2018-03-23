using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObrotPlanety : MonoBehaviour {
    [Range(1,100)]
    public float szybkoscObrotu = 1f;

    // Update is called once per frame
    void Update () {
        transform.Rotate(0, Time.deltaTime / szybkoscObrotu , 0, Space.World);
    }
}
