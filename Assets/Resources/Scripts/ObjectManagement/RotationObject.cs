using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObject : MonoBehaviour {
    [SerializeField] private PositionStates.Rotation fromPlane = PositionStates.Rotation.xPos;
    [SerializeField] private PositionStates.Rotation toPlane = PositionStates.Rotation.zNeg;

    public static UnityStringEvent onRotate = new UnityStringEvent( );

    private float triggerWidth = 0.3f;
    private bool inBoundary = false;

    private float initTravel;

    // Use this for initialization
    void Start( ) {
        // align object with the nearest floor
       // RaycastHit rHit = Physics.RaycastAll( transform.position, -transform.up )[0];
       // transform.position = new Vector3( rHit.point.x, 1, rHit.point.z ); // offset up on the y-axis to account for box collider

        // create trigger box
        BoxCollider box = gameObject.AddComponent<BoxCollider>( );
        box.isTrigger = true;
        box.size = new Vector3( triggerWidth, 5f, triggerWidth );
        tag = "TriggerRotationSwitch";
    }

    private void OnTriggerEnter( Collider other ) {
        if ( other.CompareTag( "Player" ) && !inBoundary ) {
            inBoundary = true;
            // calculate direction player is from center of rotation point
            initTravel = UpdateTravel( other.GetComponent<CharacterMovement>( ).currentRotation, other );

            StartCoroutine( "PositionMonitor", other );
        }
    }

    /// <summary>
    /// Keeps track of the character position within the checkpoint and rotates when appropriate.
    /// </summary>
    /// <param name="other">Character Collider.</param>
    /// <returns>null</returns>
    private IEnumerator PositionMonitor( Collider other ) {
        bool beginSwitch = false;
        float newTravel;
        float degrees;
        PositionStates.Rotation newDir;
        CharacterMovement pController = other.GetComponent<CharacterMovement>( );

        // set the rotation that the character will rotate to
        if ( pController.currentRotation == fromPlane ) {
            newDir = toPlane;
            degrees = GetDegrees( fromPlane, newDir );
        } else {
            newDir = fromPlane;
            degrees = GetDegrees( toPlane, newDir );
        }

        while ( inBoundary ) // continous checking while player stays in boundary
        {
            while ( !beginSwitch ) // check player position until they pass the center of the rotation point
            {
                yield return new WaitForFixedUpdate( ); // wait a frame to allow from movement from previous position

                newTravel = UpdateTravel( pController.currentRotation, other );

                // has the direction swapped from + to - or - to +?
                // indicates player passing center position
                beginSwitch = (initTravel < 0 && newTravel > 0) || (initTravel > 0 && newTravel < 0);
            }

            // Invoke rotation event
            if ( PositionStates.IsClockwise( pController.currentRotation, newDir ) )
                onRotate.Invoke( "CW" ); //clockwise
            else
                onRotate.Invoke( "CC" ); //counter-clockwise

            // call rotation from character controller
            pController.RotatePlane( newDir, transform.position, degrees );

            yield return new WaitForFixedUpdate( );

            // swap new rotation to it's inverse
            if ( newDir == fromPlane )
                newDir = toPlane;
            else
                newDir = fromPlane;

            // calculate new initTravel 
            initTravel = UpdateTravel( pController.currentRotation, other );

            beginSwitch = false;
        }
    }

    private void OnTriggerExit( Collider other ) {
        if ( other.CompareTag( "Player" ) ) {
            StopCoroutine( "PositionMonitor" );
            inBoundary = false;
        }
    }

    /// <summary>
    /// Gets a new distance from player to rotation point.
    /// </summary>
    /// <param name="playerRot">Current rotation of the player</param>
    /// <param name="other">Collider of the player</param>
    /// <returns>Floating point distance between player and rotation point.</returns>
    private float UpdateTravel( PositionStates.Rotation playerRot, Collider other ) {
        float travel = 0f;

        if ( playerRot == fromPlane ) {
            if ( fromPlane == PositionStates.Rotation.xPos || fromPlane == PositionStates.Rotation.xNeg )
                travel = other.transform.position.x - transform.position.x;
            else
                travel = other.transform.position.z - transform.position.z;
        } else {
            if ( toPlane == PositionStates.Rotation.xPos || toPlane == PositionStates.Rotation.xNeg )
                travel = other.transform.position.x - transform.position.x;
            else
                travel = other.transform.position.z - transform.position.z;
        }

        return travel;
    }

    float GetDegrees( PositionStates.Rotation from, PositionStates.Rotation to ) {
        float degrees;

        if ( (from == PositionStates.Rotation.xPos && to == PositionStates.Rotation.zPos) ||
            (from == PositionStates.Rotation.zPos && to == PositionStates.Rotation.xNeg) ||
            (from == PositionStates.Rotation.xNeg && to == PositionStates.Rotation.zNeg) ||
            (from == PositionStates.Rotation.zNeg && to == PositionStates.Rotation.xPos) ) {
            degrees = -90.0f;
        } else {
            degrees = 90.0f;
        }

            return degrees;
    }
}
