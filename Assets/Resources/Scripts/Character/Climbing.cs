using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : CharacterStates {
    private readonly CharacterMovement player;
    private Vector3 hangPos;

    private enum ClimbingDir { up = 1, down = -1, idle = 0 };
    private ClimbingDir climbing;

    public Climbing( CharacterMovement cMovement ) {
        player = cMovement;
    }

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
    }

    public void FixedUpdate( ) {
        // Ascending
        if ( climbing == ClimbingDir.up ) {
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
        }
    }

    public void SwitchToPlayerMovement( ) {
        player.GetConstraints();
        player.gameObject.GetComponent<Rigidbody>().useGravity = true;
        player.currentState = player.playerInput;
    }

    public void SwitchToRotation( ) { }
    public void OnTriggerEnter( Collider other ) { }
    public void SwitchToPlayerCrawl( ) { }
    public void SwitchToPlayerClimb( ) { }
}
