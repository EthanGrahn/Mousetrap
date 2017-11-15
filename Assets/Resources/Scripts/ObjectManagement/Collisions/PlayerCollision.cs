using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {
    private float distToGround;
    private float distToSide;

    void Start( ) {
        // Bounds of object
        distToGround = GetComponent<Collider>( ).bounds.extents.y;
        distToSide = GetComponent<Collider>( ).bounds.extents.x;
    }

    public bool RightCollided( ) {
        RaycastHit hit;
        Debug.DrawRay( transform.position, transform.right );
        Debug.DrawRay( transform.position + new Vector3( 0, distToGround, 0 ), transform.right );
        Debug.DrawRay( transform.position + new Vector3( 0, (-distToGround + .01f), 0 ), transform.right );
        if ( Physics.Raycast( transform.position, transform.right, out hit, distToSide + .1f ) ||
            Physics.Raycast( transform.position + new Vector3( 0, distToGround, 0 ), transform.right, out hit, distToSide + .1f ) ||
            Physics.Raycast( transform.position + new Vector3( 0, (-distToGround + .01f), 0 ), transform.right, out hit, distToSide + .1f ) ) {
            if ( hit.collider.GetComponent<ObjectProperties>( ) != null && hit.collider.GetComponent<ObjectProperties>( ).GetBoolProperty( "movable" ) ) {
                return false;
            }
            return true;
        }

        return false;
    }

    public bool LeftCollided( ) {
        RaycastHit hit;
        Debug.DrawRay( transform.position, -transform.right );
        Debug.DrawRay( transform.position + new Vector3( 0, distToGround, 0 ), -transform.right );
        Debug.DrawRay( transform.position + new Vector3( 0, (-distToGround + .01f), 0 ), -transform.right );
        if ( Physics.Raycast( transform.position, -transform.right, out hit, distToSide + .1f ) ||
            Physics.Raycast( transform.position + new Vector3( 0, distToGround, 0 ), -transform.right, out hit, distToSide + .1f ) ||
            Physics.Raycast( transform.position + new Vector3( 0, (-distToGround + .01f), 0 ), -transform.right, out hit, distToSide + .1f ) ) {
            if ( hit.collider.GetComponent<ObjectProperties>( ) != null && hit.collider.GetComponent<ObjectProperties>( ).GetBoolProperty( "movable" ) ) {
                return false;
            }
            return true;
        }

        return false;
    }
}
