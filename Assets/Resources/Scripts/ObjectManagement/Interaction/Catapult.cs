using UnityEngine;

public class Catapult : MonoBehaviour
{
    public Vector2 launchVector = new Vector2(0, 0);
    [SerializeField]
    private Collider enemyTrigger;

    private bool playerInPosition = false;

    /// <summary>
    /// Launch the player character and destroy the gameobject that triggered the launch.
    /// </summary>
    /// <param name="spider">Object that triggered the launch</param>
    public void Launch(GameObject spider)
    {
        if (!playerInPosition)
        {
            return;
        }

        GetComponent<Animator>().SetBool("Active", true);

        GameManager.Instance.Player.GetComponent<Rigidbody>().AddForce(Vector3.up * launchVector.y, ForceMode.VelocityChange);
        GameManager.Instance.Player.GetComponent<ValueFalloff>().StartFalloff(1, launchVector.x, false);
        Destroy(spider);
        Destroy(enemyTrigger);
    }

    /// <summary>
    /// Unity event called when another collider enters the attached trigger collider.
    /// </summary>
    /// <param name="other">Other objects collider data</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInPosition = true;
        }
    }

    /// <summary>
    /// Unity event called when another collider exits the attached trigger collider.
    /// </summary>
    /// <param name="other">Other objects collider data</param>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInPosition = false;
        }
    }
}
