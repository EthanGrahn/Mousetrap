using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultHelper : MonoBehaviour {

	[SerializeField]
	private Catapult mainScript;
	
	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Enemy"))
			mainScript.Launch(other.gameObject);
	}
}
