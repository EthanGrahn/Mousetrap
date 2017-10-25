using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour {
    private float distToGround;
    private float distToSide;

    void Start( ) {
        // Bounds of object
        distToGround = GetComponent<Collider>( ).bounds.extents.y;
        distToSide = GetComponent<Collider>( ).bounds.extents.x;
    }

    public bool RightCollided( ) {
        return Physics.Raycast( transform.position, transform.right, distToSide + .1f ) ||
            Physics.Raycast( transform.position + new Vector3( 0, distToGround, 0 ), transform.right, distToSide + .1f ) ||
            Physics.Raycast( transform.position + new Vector3( 0, (-distToGround + .01f), 0 ), transform.right, distToSide + .1f );
    }

    public bool LeftCollided( ) {
        return Physics.Raycast( transform.position, -transform.right, distToSide + .1f ) ||
            Physics.Raycast( transform.position + new Vector3( 0, distToGround, 0 ), -transform.right, distToSide + .1f ) ||
            Physics.Raycast( transform.position + new Vector3( 0, (-distToGround + .01f), 0 ), -transform.right, distToSide + .1f );
    }
}
