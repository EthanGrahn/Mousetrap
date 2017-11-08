using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : CharacterStates {
    private readonly CharacterMovement player;
<<<<<<< Updated upstream
    private Vector3 hangPos;

    private enum ClimbingDir { up = 1, down = -1, idle = 0 };
=======

    private enum ClimbingDir { up = 1, down = -1, idle = 0, jump = 2 };
>>>>>>> Stashed changes
    private ClimbingDir climbing;

    public Climbing( CharacterMovement cMovement ) {
        player = cMovement;
    }

<<<<<<< Updated upstream
    // Update is called once per frame
    public void Update( ) {
        // Get integer value for direction character is moving
        player.GetDirection();

        if ( Rebind.GetInput( "Up" ) ) {
            GetConstraints();
            climbing = ClimbingDir.up;
        } else if ( Rebind.GetInput( "Down" ) ) {
            GetConstraints();
            climbing = ClimbingDir.down;
        } else {
            GetConstraints();
            climbing = ClimbingDir.idle;
        }
=======
    public void Update( ) {
        // Get integer value for direction character is moving
        player.GetDirection( );

        // Get input for climbing up or down the wall
        if ( Input.GetKey( KeyCode.W ) ) {
            climbing = ClimbingDir.up;
            GetConstraints( );
        } else if ( Input.GetKey( KeyCode.S ) ) {
            climbing = ClimbingDir.down;
            GetConstraints( );
        } else {
            GetConstraints( );
            climbing = ClimbingDir.idle;
        }

        if ( Input.GetKeyDown( KeyCode.Space ) ) {
            climbing = ClimbingDir.jump;
            GetConstraints( );
            player.gameObject.GetComponent<Rigidbody>( ).useGravity = true;
            // can't get player to jump or move away from wall
            PositionStates.Direction dir;
            if ( player.coll.RightCollided( ) )
                dir = PositionStates.Direction.left;
            else
                dir = PositionStates.Direction.right;
            player.SetHorizontalMovement( dir );
            SwitchToPlayerMovement( );
        }
>>>>>>> Stashed changes
    }

    public void FixedUpdate( ) {
        // Ascending
        if ( climbing == ClimbingDir.up ) {
<<<<<<< Updated upstream
            player.GetComponent<Rigidbody>().velocity = new Vector3( 0, player.climbSpeed, 0 );
        }
        // Descending
        else if ( climbing == ClimbingDir.down ) {
            player.GetComponent<Rigidbody>().velocity = new Vector3( 0, -player.climbSpeed, 0 );
        }

        // Horizontal movement
        player.SetHorizontalMovement();
    }

    public void OnTriggerExit( Collider other ) {
        SwitchToPlayerMovement();
    }

    private void GetConstraints( ) {
        player.GetConstraints();
        if ( climbing == ClimbingDir.idle ) {
            player.GetComponent<Rigidbody>().constraints |= RigidbodyConstraints.FreezePositionY;
=======
            player.GetComponent<Rigidbody>( ).velocity = new Vector3( 0, player.climbSpeed, 0 );
        }
        // Descending
        else if ( climbing == ClimbingDir.down ) {
            player.GetComponent<Rigidbody>( ).velocity = new Vector3( 0, -player.climbSpeed, 0 );
        }

        // Horizontal movement
        player.SetHorizontalMovement( );
    }

    public void OnTriggerExit( Collider other ) {
        SwitchToPlayerMovement( );
    }

    private void GetConstraints( ) {
        PositionStates.GetConstraints( player.gameObject, player.currentRotation );
        if ( climbing == ClimbingDir.idle ) {
            player.GetComponent<Rigidbody>( ).constraints |= RigidbodyConstraints.FreezePositionY;
>>>>>>> Stashed changes
        }
    }

    public void SwitchToPlayerMovement( ) {
<<<<<<< Updated upstream
        player.GetConstraints();
        player.gameObject.GetComponent<Rigidbody>().useGravity = true;
=======
        if ( climbing == ClimbingDir.jump ) {
            player.GetComponent<Rigidbody>( ).velocity = new Vector3( player.GetComponent<Rigidbody>( ).velocity.x,
                player.jumpSpeed, player.GetComponent<Rigidbody>( ).velocity.z );
        }
        PositionStates.GetConstraints( player.gameObject, player.currentRotation );
        player.gameObject.GetComponent<Rigidbody>( ).useGravity = true;
>>>>>>> Stashed changes
        player.currentState = player.playerInput;
    }

    public void SwitchToRotation( ) { }
    public void OnTriggerEnter( Collider other ) { }
    public void SwitchToPlayerCrawl( ) { }
    public void SwitchToPlayerClimb( ) { }
}
