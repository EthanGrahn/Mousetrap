using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebTrap : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			// limit velocity
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			// Reset velocity limit
		}
	}
}
