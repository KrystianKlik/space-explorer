using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public float revolvingSpeed;

    public float Xaxis;
    public float Zaxis;
    public float Yaxis;
    public Transform centerPoint;

    public float rotSpeed = 1.0f;
    public bool rotateClockwise;

    float timer = 0;



    // Update is called once per frame
    void Update()
    {
        timer += ((Time.deltaTime * rotSpeed)/1000);
        Rotate();
        ObrotWokolOsi();
    }

    void Rotate()
    {
        if (rotateClockwise)
        {
            float x = -Mathf.Cos(timer) * Xaxis;
            float z = Mathf.Sin(timer) * Zaxis;
            Vector3 pos = new Vector3(x, Yaxis, z);
            transform.position = pos + centerPoint.position;
        }
        else
        {
            float x = Mathf.Cos(timer) * Xaxis;
            float z = Mathf.Sin(timer) * Zaxis;
            Vector3 pos = new Vector3(x, Yaxis, z);
            transform.position = pos + centerPoint.position;
        }
    }

    void ObrotWokolOsi()
    {
        transform.Rotate(Vector3.up, revolvingSpeed * Time.deltaTime);
    }


}





