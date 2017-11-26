using UnityEngine;

public class Gravity : MonoBehaviour {

    public Rigidbody rb;

    // Use this for initialization
    void Start () {

        rb.useGravity = false; //Dla pewnosci wylaczona grawitacja
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.AddForce(0, 0, 0 * Time.deltaTime);
	}
}
