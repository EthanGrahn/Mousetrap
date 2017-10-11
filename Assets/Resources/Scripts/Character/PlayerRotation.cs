using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : CharacterStates {
    private readonly CharacterMovement player;
    private bool rotating = false;
    private float rotSpeed = 100;
    private float endingDist = 6;
    private float distFromPoint = 0.15f;
    float inTime = 1.1f;

    public PlayerRotation( CharacterMovement characterMovement ) {
        player = characterMovement;
    }

    IEnumerator MoveToPoint( ) {
        rotating = true;
        // Make sure rotation is kept on ground
        while ( !player.grav.IsGrounded( ) ) {
            yield return null;
        }

        // Set new point to grounded position
        Vector3 groundedPos = player.rotationPoint;
        groundedPos.y = player.transform.position.y;
        player.rotationPoint = groundedPos;

        // Move character to point of rotation
        PositionStates.Direction dir = GetDirection( player.rotationPoint );
        bool thing = true;
        while ( Vector3.Distance( player.transform.position, player.rotationPoint ) > distFromPoint && thing ) {
            thing = false;
            HorizontalMovement( dir );
            Debug.Log( "Inside movement while, player direction = " + dir + " " + (int)dir + " " + Vector3.Distance(player.rotationPoint, player.transform.position) + player.GetComponent<Rigidbody>().velocity );
            thing = true;
            yield return new WaitForFixedUpdate();
        }
        Debug.Log( "Outside of movement while" );
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
            yield return null;
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
            yield return null;
        }
        GetConstraints( );

        // Move player to outside of trigger area
        Vector3 targetPosition = player.transform.position;
        targetPosition = GetEndingPosition( targetPosition );

        while ( Vector3.Distance( player.transform.position, targetPosition ) > distFromPoint ) {
            HorizontalMovement( player.endingDirection );
            Debug.Log( "Inside end movement while, player direction = " + player.endingDirection + " " + Vector3.Distance(targetPosition, player.transform.position) );
            yield return new WaitForFixedUpdate( );
        }
        Debug.Log( "Outside end movement while" );

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
    private void HorizontalMovement( PositionStates.Direction dir ) {
        // Horizontal movement
        float horVel = (int)dir * player.speedUpFactor;
        if ( player.currentRotation == PositionStates.Rotation.zero )
            player.GetComponent<Rigidbody>( ).velocity = new Vector3( horVel, 0.0f, 0.0f );
        else if ( player.currentRotation == PositionStates.Rotation.one )
            player.GetComponent<Rigidbody>( ).velocity = new Vector3( 0.0f, 0.0f, horVel );
        else if ( player.currentRotation == PositionStates.Rotation.two )
            player.GetComponent<Rigidbody>( ).velocity = new Vector3( -horVel, 0.0f, 0.0f );
        else if ( player.currentRotation == PositionStates.Rotation.three )
            player.GetComponent<Rigidbody>( ).velocity = new Vector3( 0.0f, 0.0f, -horVel );
    }

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

    private void GetConstraints( ) {
        if ( player.currentRotation == PositionStates.Rotation.zero ||
            player.currentRotation == PositionStates.Rotation.two )
            player.GetComponent<Rigidbody>( ).constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
        else
            player.GetComponent<Rigidbody>( ).constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX;
    }

    //---------------------------------------------UNUSED----------------------------------------------//
    public void Update( ) {
        // Do nothing
    }

    public void OnTriggerEnter( Collider other ) {
        // Do nothing
    }

    public void SwitchToRotation( ) {
        // Can't switch to same state
    }

    public void SwitchToPlayerCrawl( ) {
        // Do nothing
    }
}
