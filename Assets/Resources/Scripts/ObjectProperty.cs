using UnityEngine;

public class ObjectProperty : MonoBehaviour {

    /// <summary>
    /// Type of interactable object.
    /// </summary>
    public enum ObjectType
    {
        Climbable,
        Smashable,
        Pushable
    }

    public ObjectType objectType;

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.GetComponent<ObjectProperty>().objectType)
        {
            case ObjectType.Climbable:

                break;
            case ObjectType.Smashable:

                break;
            case ObjectType.Pushable:

                break;
            default:
                break;
        }
    }
}
