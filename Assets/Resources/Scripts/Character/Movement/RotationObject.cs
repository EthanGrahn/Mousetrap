using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObject : MonoBehaviour {

	[SerializeField] private PositionStates.Rotation fromPlane = PositionStates.Rotation.xPos;
	[SerializeField] private PositionStates.Rotation toPlane = PositionStates.Rotation.zPos;

	public static UnityStringEvent onRotate = new UnityStringEvent();

	private float triggerWidth = 0.3f;
	private bool inBoundary = false;
	private bool invert = false;

	private float initTravel;

	// Use this for initialization
	void Start () {		
		invert = (fromPlane > 0 && toPlane < 0) || (fromPlane < 0 && toPlane > 0); // should this checkpoint invert horizontal controls?
		
		// align object with the nearest floor
		RaycastHit rHit = Physics.RaycastAll(transform.position, -transform.up)[0];
		transform.position = new Vector3(rHit.point.x, 1, rHit.point.z); // offset up on the y-axis to account for box collider

		// create trigger box
		BoxCollider box = gameObject.AddComponent<BoxCollider>();
		box.isTrigger = true;
		box.size = new Vector3(triggerWidth, 5f, triggerWidth);
	}

	private void OnTriggerEnter(Collider other) {
		if (CompareTag("Player"))
		{
			// calculate direction player is from center of rotation point
			if (other.GetComponent<CharacterController.PlatformerCharacter>().currentRotation == fromPlane)
			{
				if (Mathf.Abs((int)fromPlane) == 1)
					initTravel = other.transform.position.x - transform.position.x;
				else
					initTravel = other.transform.position.z - transform.position.z;
			}
			else
			{
				if (Mathf.Abs((int)toPlane) == 1)
					initTravel = other.transform.position.x - transform.position.x;
				else
					initTravel = other.transform.position.z - transform.position.z;
			}
				
			inBoundary = true;
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
		float newTravel;
		PositionStates.Rotation newDir;
		CharacterController.PlatformerCharacter pController = other.GetComponent<CharacterController.PlatformerCharacter>();

		// set the rotation that the character will rotate to
		if (pController.currentRotation == fromPlane)
			newDir = toPlane;
		else
			newDir = fromPlane;

        while (inBoundary) // continous checking while player stays in boundary
        {
            while (!beginSwitch) // check player position until they pass the center of the rotation point
            {
                yield return new WaitForFixedUpdate(); // wait a frame to allow from movement from previous position

				// calculate new direction player is from the center of the rotation point
                if (pController.currentRotation == fromPlane)
                {
                    if (Mathf.Abs((int)fromPlane) == 1)
                        newTravel = other.transform.position.x - transform.position.x;
                    else
                        newTravel = other.transform.position.z - transform.position.z;
                }
                else
                {
                    if (Mathf.Abs((int)toPlane) == 1)
                        newTravel = other.transform.position.x - transform.position.x;
                    else
                        newTravel = other.transform.position.z - transform.position.z;
                }

                // has the direction swapped from + to - or - to +?
				// indicates player passing center position
                beginSwitch = (initTravel < 0 && newTravel > 0) || (initTravel > 0 && newTravel < 0);
            }

			// Invoke rotation event
			if (PositionStates.IsClockwise(pController.currentRotation, newDir))
				onRotate.Invoke("CW"); //clockwise
			else
				onRotate.Invoke("CC"); //counter-clockwise

            // call rotation from character controller
            pController.RotatePlane(newDir, transform.position, invert);

			yield return new WaitForFixedUpdate();

			// swap new rotation to it's inverse
			if (newDir == fromPlane)
				newDir = toPlane;
			else
				newDir = fromPlane;

			// calculate new initTravel 
			if (pController.currentRotation == fromPlane)
			{
				if (Mathf.Abs((int)fromPlane) == 1)
					initTravel = other.transform.position.x - transform.position.x;
				else
					initTravel = other.transform.position.z - transform.position.z;
			}
			else
			{
				if (Mathf.Abs((int)toPlane) == 1)
					initTravel = other.transform.position.x - transform.position.x;
				else
					initTravel = other.transform.position.z - transform.position.z;
			}
			
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
