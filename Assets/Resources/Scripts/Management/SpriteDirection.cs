using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDirection : MonoBehaviour {

    Sprite sprite;

	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>( ).sprite;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
