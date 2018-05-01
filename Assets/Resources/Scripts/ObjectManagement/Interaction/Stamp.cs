using UnityEngine;

/// <summary>
/// Changes TextMesh when this object's trigger is entered by the stamp object.
/// </summary>
public class Stamp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stamp"))
        {
            other.GetComponent<TextMesh>().text = "ACCEPTED";
            Destroy(this);
        }
    }
}
