using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebTrap : MonoBehaviour {

	[Range(0, 1)]
	[SerializeField] private float speedModifier = 0.5f;

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			GameManager.Instance.pMovement.SetSpeedModifier(speedModifier);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			GameManager.Instance.pMovement.SetSpeedModifier(1);
		}
	}
}
