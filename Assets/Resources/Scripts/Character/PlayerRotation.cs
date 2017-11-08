using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : CharacterStates {
    private readonly CharacterMovement player;
    private bool rotating = false;
    private float endingDist = 6;
    private float distFromPoint = 0.15f;
    float inTime = 1.2f;

    public PlayerRotation( CharacterMovement characterMovement ) {
        player = characterMovement;
    }

    IEnumerator MoveToPoint( ) {
        rotating = true;
        // Make sure rotation is kept on ground
        while ( !player.grav.IsGrounded( ) ) {
            yield return new WaitForFixedUpdate( );
        }

        // Set new point to grounded position
        Vector3 groundedPos = player.rotationPoint;
        groundedPos.y = player.transform.position.y;
        player.rotationPoint = groundedPos;

        // Move character to point of rotation
        player.currDirection = GetDirection( player.rotationPoint );
        while ( Vector3.Distance( player.transform.position, player.rotationPoint ) > distFromPoint ) {
            player.SetHorizontalMovement( player.currDirection );
            yield return new WaitForFixedUpdate( );
        }
        player.transform.position = player.rotationPoint;
        player.GetComponent<Rigidbody>( ).velocity = new Vector3( 0, 0, 0 );

        // Rotate the camera
        float cameraAngle = player.mainCam.transform.eulerAngles.y;
        cameraAngle += player.rotationAdd % 360;
        Quaternion cameraRotation = Quaternion.identity;
        cameraRotation = Quaternion.Euler( 0.0f, cameraAngle, 0.0f );

        player.currentRotation = player.endingRotation;

        for ( float t = 0f; t < 1; t += Time.deltaTime / inTime ) {
            player.mainCam.transform.rotation = Quaternion.Lerp( player.mainCam.transform.rotation, cameraRotation, t );
            yield return new WaitForFixedUpdate( );
        }

        player.mainCam.transform.rotation = cameraRotation;

        // Rotate the player
        player.GetComponent<Rigidbody>( ).constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        float targetAngle = player.transform.eulerAngles.y;
        targetAngle += player.rotationAdd % 360;
        Quaternion targetRotation = Quaternion.identity;
        targetRotation = Quaternion.Euler( 0.0f, targetAngle, 0.0f );

        for ( float t = 0f; t < 1; t += Time.deltaTime / inTime ) {
            player.transform.rotation = Quaternion.Lerp( player.transform.rotation, targetRotation, t );
            yield return new WaitForFixedUpdate( );
        }
        player.GetConstraints( );

        // Move player to outside of trigger area
        Vector3 targetPosition = player.transform.position;
        targetPosition = GetEndingPosition( targetPosition );

        while ( Vector3.Distance( player.transform.position, targetPosition ) > distFromPoint ) {
            player.SetHorizontalMovement( player.endingDirection );
            yield return new WaitForFixedUpdate( );
        }

        SwitchToPlayerMovement( );
        rotating = false;
    }
    //--------------------------------------------------------------------------------------------------//
    //----------------------------------------END OF IENUMERATOR----------------------------------------//
    //--------------------------------------------------------------------------------------------------//


    //--------------------------------------------------------------------------------------------------//
    //-----------------------------------------STATE FUNCTIONS------------------------------------------//
    //--------------------------------------------------------------------------------------------------//
    public void FixedUpdate( ) {
        if ( !rotating )
            player.StartStateCoroutine( MoveToPoint( ) );
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
            if ( player.lastDirection == PositionStates.Direction.left ) {
                targetPosition.x -= endingDist;
            } else {
                targetPosition.x += endingDist;
            }
        } else if ( player.currentRotation == PositionStates.Rotation.one ) {
            if ( player.lastDirection == PositionStates.Direction.left ) {
                targetPosition.z -= endingDist;
            } else {
                targetPosition.z += endingDist;
            }
        } else if ( player.currentRotation == PositionStates.Rotation.two ) {
            if ( player.lastDirection == PositionStates.Direction.left ) {
                targetPosition.x += endingDist;
            } else {
                targetPosition.x -= endingDist;
            }
        } else if ( player.currentRotation == PositionStates.Rotation.three ) {
            if ( player.lastDirection == PositionStates.Direction.left ) {
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
