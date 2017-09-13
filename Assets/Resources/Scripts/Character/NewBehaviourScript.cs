using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    public Transform axis;

	// Use this for initialization
	void Start () {
        transform.RotateAround( axis.position, Vector3.up, -90 );
	}
	
	// Update is called once per frame
	void Update () {
	}
}
