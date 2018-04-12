using UnityEngine;

public class Catapult : MonoBehaviour {

	public Vector2 launchVector = new Vector2(0, 0);
	[SerializeField]
	private Collider enemyTrigger;

	private bool playerInPosition = false;

	public void Launch(GameObject spider)
	{
		if (!playerInPosition)
			return;
			
		GetComponent<Animator>().SetBool("Active", true);

		GameManager.Instance.Player.GetComponent<Rigidbody>().AddForce(Vector3.up * launchVector.y, ForceMode.VelocityChange);
		GameManager.Instance.Player.GetComponent<ValueFalloff>().StartFalloff(1, launchVector.x, false);
		Destroy(spider);
		Destroy(enemyTrigger);
	}

	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player"))
			playerInPosition = true;
	}

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInPosition = false;
    }
}
