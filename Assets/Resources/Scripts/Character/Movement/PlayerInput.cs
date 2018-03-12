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
    }

    public void OnTriggerStay( Collider other ) {
        if ( other.CompareTag( "Climbable" ) ) {
            Debug.Log( "Hit climbable object" );
            if ( player.controller.Up || player.controller.Down )
                SwitchToPlayerClimb( );
        }
    }

    //-----------------------------------------SWITCHING STATE-----------------------------------------//
    public void SwitchToPlayerClimb( ) {
        player.gameObject.GetComponent<Rigidbody>( ).useGravity = false;
        player.currentState = player.climbing;
    }

    //---------------------------------------------UNUSED----------------------------------------------//
    public void SwitchToPlayerMovement( ) { }
    public void OnTriggerExit( Collider other ) { }
    public void OnTriggerEnter( Collider other ) { }
}
