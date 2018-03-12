using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinCan : MonoBehaviour {

    public GameObject tether;
    Rigidbody rBody;
    
	// Use this for initialization
	void Start () {
        rBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (tether == null && rBody.isKinematic)
        {
            rBody.isKinematic = false;
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EndWall"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
