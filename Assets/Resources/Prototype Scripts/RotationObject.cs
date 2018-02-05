using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObject : MonoBehaviour {

	public enum plane
	{
		xPos =  1,
		xNeg = -1,
		zPos =  2,
		zNeg = -2
	}

	[SerializeField] private float triggerWidth = 0.15f;
	[SerializeField] private plane fromPlane = plane.xPos;
	[SerializeField] private plane toPlane = plane.zPos;

	private plane currPlane;
	private bool switched = false;
	private bool rotating = false;

	// Use this for initialization
	void Start () {
		currPlane = fromPlane;

		// align object with the nearest floor
		RaycastHit rHit = Physics.RaycastAll(transform.position, -transform.up)[0];
		transform.position = new Vector3(rHit.point.x, 1, rHit.point.z); // offset up on the y-axis to account for box collider

		// create trigger box
		BoxCollider box = gameObject.AddComponent<BoxCollider>();
		box.isTrigger = true;
		box.size = new Vector3(triggerWidth, 5f, triggerWidth);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerStay(Collider other) {
		if (!rotating && other.CompareTag("Player") && 
		    Vector2.Distance(new Vector2(transform.position.x, transform.position.z), 
							 new Vector2(other.transform.position.x, other.transform.position.z)) <= 0.5f)
		{
			if (currPlane == fromPlane)
				currPlane = toPlane;
			else
				currPlane = fromPlane;
				
			rotating = true;
			switched = !switched;
			Vector3 heading = transform.position - other.transform.position;
			Vector3 direction = heading / heading.magnitude;
			bool xPlane = direction.x == 0;
			bool invert = (fromPlane < 0 && fromPlane == currPlane) || (toPlane < 0 && toPlane == currPlane);
			//Debug.Log(direction.normalized);
			other.GetComponent<CharacterController.PlatformerCharacter>().RotatePlane(xPlane, transform.position, invert);
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.CompareTag("Player"))
		{
			rotating = false;
		}
	}
}
