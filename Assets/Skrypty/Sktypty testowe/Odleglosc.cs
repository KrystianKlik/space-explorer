using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Odleglosc : MonoBehaviour
{
    public float odleglosc;
    public Collider coll;

    public void Samolot(float maxHeight, float maxDistance)
    {
      

        
    
     }
    //https://answers.unity.com/questions/1090051/most-efficient-way-to-find-the-closest-collider-to.html

    void Start()
    {

        coll = GetComponent<Collider>();
    }

     void Update()
    {
   //     LeciSamolocik();
    }

    //void LeciSamolocik()//mierzy odleglosc
    //{
    //    Vector3 closestPoint = coll.ClosestPointOnBounds(odleglosc);
    //    float distance = Vector3.Distance(closestPoint, samolot);
    //}


}