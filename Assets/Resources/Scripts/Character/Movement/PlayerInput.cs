using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : CharacterStates {
    private readonly CharacterMovement player;
    //--------------------------------------------------------------------------------------------------//
    //-----------------------------------------STATE FUNCTIONS------------------------------------------//
    //--------------------------------------------------------------------------------------------------//

    public PlayerInput( CharacterMovement characterMovement ) {
        player = characterMovement;
    }

    public void Update( ) {
        // Get integer value for direction character is moving
        player.directions.GetDirection( );
    }

    public void FixedUpdate( ) {
        // Horizontal movement
        player.SetHorizontalMovement( player.directions.currDirection );

        // Jumping
        player.Jumping( );

        // Falling
        
    }

    public void OnTriggerEnter( Collider other ) {
        if ( other.CompareTag( "Climbable" ) ) {
            SwitchToPlayerClimb( );
        }
    }

    //-----------------------------------------SWITCHING STATE-----------------------------------------//
    public void SwitchToRotation( ) {
        Vector3 vel = new Vector3( 0, player.GetComponent<Rigidbody>( ).velocity.y, 0 );
        player.GetComponent<Rigidbody>( ).velocity = vel;
        player.currentState = player.playerRotation;
    }

    public void SwitchToPlayerCrawl( ) {
        // Need to implement
    }

    public void SwitchToPlayerClimb( ) {
        player.gameObject.GetComponent<Rigidbody>( ).useGravity = false;
        player.currentState = player.climbing;
    }

    //---------------------------------------------UNUSED----------------------------------------------//
    public void SwitchToPlayerMovement( ) { }
    public void OnTriggerExit( Collider other ) { }
}
