using UnityEngine;

public class Catapult : MonoBehaviour {

	[SerializeField]
	private Vector3 launchVector = new Vector3(0, 0, 0);

	public Vector3 Launch()
	{
		//trigger animation
		return launchVector;
	}
}
