using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwiewkaDemo : MonoBehaviour {

    public Rigidbody owiewka;
    public ConfigurableJoint CFJ;
    public ConfigurableJoint dolnyBooster;
    public float wystrzal;
    float time = 10f;
    bool odczepione = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(dolnyBooster == null)
        {
            time -= Time.deltaTime;
            if(time <=0 && !odczepione)
            {
                CFJ.breakForce = 0;
                odczepione = true;
                StartCoroutine(Moc());
               // owiewka.AddRelativeForce(wystrzal, 0, 0);
            }
        }

	}

    IEnumerator Moc()
    {
        yield return new WaitForSeconds(.1f);
        owiewka.AddRelativeForce(wystrzal, 0, 0, ForceMode.Impulse);
    }

}
