using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : CharacterStates {
    private readonly CharacterMovement player;
    private bool rotating = false;
    private float endingDist = 6;
    private float distFromPoint = 0.15f;

    public PlayerRotation( CharacterMovement characterMovement ) {
        player = characterMovement;
    }

    void MoveToPoint( ) {
        // Set new point to grounded position
        Vector3 groundedPos = player.rotationPoint;
        groundedPos.y = player.transform.position.y;
        player.rotationPoint = groundedPos;

        // Move character to point of rotation
        player.transform.position = player.rotationPoint;

        player.rotation = true;

        SwitchToPlayerMovement( );
    }
    //--------------------------------------------------------------------------------------------------//
    //------------------------------------------END OF ROTATE-------------------------------------------//
    //--------------------------------------------------------------------------------------------------//


    //--------------------------------------------------------------------------------------------------//
    //-----------------------------------------STATE FUNCTIONS------------------------------------------//
    //--------------------------------------------------------------------------------------------------//
    public void FixedUpdate( ) {
            MoveToPoint( );
    }

    public void SwitchToPlayerMovement( ) {
        player.currentState = player.playerInput;
    }


    //---------------------------------------------MOVEMENT---------------------------------------------//
    private PositionStates.Direction GetDirection( Vector3 targetPosition ) {
        PositionStates.Direction dir;
        if ( player.currentRotation == PositionStates.Rotation.zero ) {
            if ( targetPosition.x > player.transform.position.x ) {
                dir = PositionStates.Direction.right;
            } else {
                dir = PositionStates.Direction.left;
            }
        } else if ( player.currentRotation == PositionStates.Rotation.one ) {
            if ( targetPosition.z > player.transform.position.z ) {
                dir = PositionStates.Direction.right;
            } else {
                dir = PositionStates.Direction.left;
            }
        } else if ( player.currentRotation == PositionStates.Rotation.two ) {
            if ( targetPosition.x < player.transform.position.x ) {
                dir = PositionStates.Direction.right;
            } else {
                dir = PositionStates.Direction.left;
            }
        } else {
            if ( targetPosition.z < player.transform.position.z ) {
                dir = PositionStates.Direction.right;
            } else {
                dir = PositionStates.Direction.left;
            }
        }

        return dir;
    }

    private Vector3 GetEndingPosition( Vector3 targetPosition ) {
        if ( player.currentRotation == PositionStates.Rotation.zero ) {
            if ( player.directions.lastDirection == PositionStates.Direction.left ) {
                targetPosition.x -= endingDist;
            } else {
                targetPosition.x += endingDist;
            }
        } else if ( player.currentRotation == PositionStates.Rotation.one ) {
            if ( player.directions.lastDirection == PositionStates.Direction.left ) {
                targetPosition.z -= endingDist;
            } else {
                targetPosition.z += endingDist;
            }
        } else if ( player.currentRotation == PositionStates.Rotation.two ) {
            if ( player.directions.lastDirection == PositionStates.Direction.left ) {
                targetPosition.x += endingDist;
            } else {
                targetPosition.x -= endingDist;
            }
        } else if ( player.currentRotation == PositionStates.Rotation.three ) {
            if ( player.directions.lastDirection == PositionStates.Direction.left ) {
                targetPosition.z += endingDist;
            } else {
                targetPosition.z -= endingDist;
            }
        }

        return targetPosition;
    }

    //---------------------------------------------ROTATION---------------------------------------------//
    private bool QuaternionsEqual( Quaternion q1, Quaternion q2 ) {
        return (q1.Equals( q2 ) || (q1 == q2));
    }

    //---------------------------------------------UNUSED----------------------------------------------//
    public void Update( ) { }
    public void OnTriggerEnter( Collider other ) { }
    public void SwitchToRotation( ) { }
    public void SwitchToPlayerCrawl( ) { }
    public void OnTriggerExit( Collider other ) { }
    public void SwitchToPlayerClimb( ) { }
}
