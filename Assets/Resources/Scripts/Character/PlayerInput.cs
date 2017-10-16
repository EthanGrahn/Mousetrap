using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : CharacterStates
{
    private readonly CharacterMovement player;

    public PlayerInput(CharacterMovement characterMovement)
    {
        player = characterMovement;
    }

    // Update is called once per frame
    public void Update()
    {
        // Get integer value for direction character is moving
        player.GetDirection( );
    }

    public void FixedUpdate()
    {
        // Horizontal movement
        player.SetHorizontalMovment( );

        // Jumping
        if ( Rebind.GetInputDown( "Up" ) && player.grav.IsGrounded( ) ) {
            player.GetComponent<Rigidbody>( ).velocity = new Vector3( player.GetComponent<Rigidbody>( ).velocity.x,
                player.jumpSpeed, player.GetComponent<Rigidbody>( ).velocity.z );
        }

        // Falling
        if (!player.grav.IsGrounded())
        {
            player.grav.StartGravity();
        }
    }

    public void SwitchToRotation( ) {
        Vector3 vel = new Vector3( 0, player.GetComponent<Rigidbody>( ).velocity.y, 0 );
        player.GetComponent<Rigidbody>( ).velocity = vel;
        player.currentState = player.playerRotation;
    }

    public void SwitchToPlayerMovement()
    {
        // Do nothing, can't switch to same state
    }

    public void SwitchToPlayerCrawl( ) {
        // Need to implement
    }

    public void SwitchToPlayerClimb( ) {
        player.gameObject.GetComponent<Rigidbody>( ).useGravity = false;
        player.currentState = player.climbing;
    }

    public void OnTriggerEnter( Collider other ) {
        if ( other.CompareTag("TriggerRotationSwitch") ) {
            player.rotationAdd = (int)other.GetComponent<RotationVars>( ).rotationDir;
            player.endingRotation = other.GetComponent<RotationVars>( ).endingRotation;
            player.endingDirection = other.GetComponent<RotationVars>( ).endingDirection;
            Vector3 point = other.transform.parent.transform.position;
            player.rotationPoint = new Vector3(point.x, player.transform.position.y, point.z);
            SwitchToRotation();
        } else if (other.CompareTag("Climbable")) {
            SwitchToPlayerClimb( );
        }
    }

    public void OnTriggerExit(Collider other) {

    }
}
