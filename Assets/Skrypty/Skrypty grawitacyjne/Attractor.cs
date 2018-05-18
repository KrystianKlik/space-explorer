using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{

     const float upperG = 6.6674f;
    const float downG = 6.674f;

    public static List<Attractor> Attractors;

    public Rigidbody rb;
    public Rigidbody ziemia;
    float wysokosc;

    void FixedUpdate()
    {
        wysokosc = Vector3.Distance(rb.transform.position, ziemia.transform.position) * 100;
        wysokosc -= 2545000;

        foreach (Attractor attractor in Attractors)
        {
            if (attractor != this)
                Attract(attractor);
        }
    }

    void OnEnable()
    {
        if (Attractors == null)
            Attractors = new List<Attractor>();

        Attractors.Add(this);
    }

    void OnDisable()
    {
        Attractors.Remove(this);
    }

    void Attract(Attractor objToAttract)
    {
        Rigidbody rbToAttract = objToAttract.rb;
        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;
    

        if (distance <= 1000f)
        {
            return;
        }
   
      
       if(wysokosc < 90000)
        {
            float forceMagnitude = downG * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
            Vector3 force = direction.normalized * forceMagnitude;
            rbToAttract.AddForce(force);
        }
            
       if(wysokosc >= 90000)
        {
            float forceMagnitude = upperG * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
            Vector3 force = direction.normalized * forceMagnitude;
            rbToAttract.AddForce(force);
        }



    }

}