using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    private float distToGround;
    private float distToSide;

    void Start()
    {
        // Bounds of object
        distToGround = GetComponent<Collider>().bounds.extents.y;
        distToSide = GetComponent<Collider>().bounds.extents.x;
    }

    /// <summary>
    /// Raycast to the right of the object and check for collision.
    /// </summary>
    /// <returns>True if raycast detects an object blocking the path</returns>
    public bool RightCollided()
    {
        return Physics.Raycast(transform.position, transform.right, distToSide + .1f) ||
            Physics.Raycast(transform.position + new Vector3(0, distToGround, 0), transform.right, distToSide + .1f) ||
            Physics.Raycast(transform.position + new Vector3(0, (-distToGround + .01f), 0), transform.right, distToSide + .1f);
    }

    /// <summary>
    /// Raycast to the left of the object and check for collision.
    /// </summary>
    /// <returns>True if raycast detects an object blocking the path</returns>
    public bool LeftCollided()
    {
        return Physics.Raycast(transform.position, -transform.right, distToSide + .1f) ||
            Physics.Raycast(transform.position + new Vector3(0, distToGround, 0), -transform.right, distToSide + .1f) ||
            Physics.Raycast(transform.position + new Vector3(0, (-distToGround + .01f), 0), -transform.right, distToSide + .1f);
    }
}
