using UnityEngine;

/// <summary>
/// Attached to the gameobject that contains the enemy trigger. Calls the parent Catapult script.
/// </summary>
public class CatapultHelper : MonoBehaviour
{
    [SerializeField]
    private Catapult mainScript;

    /// <summary>
    /// Unity event called when a collider enters the attached trigger collider.
    /// </summary>
    /// <param name="other">Other object's collider data</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            mainScript.Launch(other.gameObject);
        }
    }
}
