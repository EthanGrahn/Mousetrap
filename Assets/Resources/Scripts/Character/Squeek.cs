﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squeek : MonoBehaviour {

    public List<string> keys = new List<string>();

    AudioSource aSource;

    // Use this for initialization
    void Start () {
        aSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown && Input.inputString.Length > 0)
        {
            if (!keys.Contains(Input.inputString.ToLower()))
            {
                Debug.Log(Input.inputString);
                aSource.pitch = Random.Range(1f,2f);
                aSource.Play();
            }
        }
	}
}
