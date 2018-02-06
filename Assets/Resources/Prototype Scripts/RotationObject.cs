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

	private static bool controlsInverted = false;

	[SerializeField] private plane fromPlane = plane.xPos;
	[SerializeField] private plane toPlane = plane.zPos;

	private float triggerWidth = 0.3f;
	private plane currPlane;
	private bool pastCenter = false;
	private bool inBoundary = false;
	private bool posTravel = true;
	private bool xPlane = false;
	private bool invert = false;

	// Use this for initialization
	void Start () {
		currPlane = fromPlane;
		
		invert = (fromPlane > 0 && toPlane < 0) || (fromPlane < 0 && toPlane > 0); // should this checkpoint invert horizontal controls?

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

	private void OnTriggerEnter(Collider other) {
		if (CompareTag("Player"))
		{
			inBoundary = true;
			Vector3 heading = transform.position - other.transform.position;
			Vector3 direction = heading / heading.magnitude;
			xPlane = direction.x == 0; // switch to x-plane?
			posTravel = ((Mathf.Round(direction.x * 100) / 100) > 0) || ((Mathf.Round(direction.z * 100) / 100) > 0);

			StartCoroutine("PositionMonitor", other);
		}
	}

	/// <summary>
	/// Keeps track of the character position within the checkpoint and rotates when appropriate.
	/// </summary>
	/// <param name="other">Character Collider.</param>
	/// <returns>null</returns>
	private IEnumerator PositionMonitor(Collider other) {
		bool beginSwitch = false;
        Vector3 heading;
        Vector3 direction;
        bool currTravel;

        while (inBoundary)
        {
            while (!beginSwitch)
            {
                yield return new WaitForFixedUpdate(); // wait a frame to allow from movement from previous position

                // calculate direction
                heading = transform.position - other.transform.position;
                direction = heading / heading.magnitude;

                // check for positive travel direction in the x or z plane
                currTravel = ((Mathf.Round(direction.x * 100) / 100) > 0) || ((Mathf.Round(direction.z * 100) / 100) > 0);

                beginSwitch = currTravel != posTravel; // is the player still moving towards the center of checkpoint
            }

            // call rotation from character controller
            other.GetComponent<CharacterController.PlatformerCharacter>().RotatePlane(xPlane, transform.position, invert);

			yield return new WaitForFixedUpdate();

            // set new variables for rotated plane
            heading = transform.position - other.transform.position;
            direction = heading / heading.magnitude;
            xPlane = !xPlane;
            posTravel = ((Mathf.Round(direction.x * 100) / 100) > 0) || ((Mathf.Round(direction.z * 100) / 100) > 0);
			beginSwitch = false;
        }
	}

	private void OnTriggerExit(Collider other) {
		if (other.CompareTag("Player"))
		{
			StopCoroutine("PositionMonitor");
			inBoundary = false;
		}
	}
}
