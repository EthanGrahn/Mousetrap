using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : CharacterStates {
    private readonly CharacterMovement player;

    public PlayerRotation (CharacterMovement characterMovement) {
        player = characterMovement;
    }
	
	// Update is called once per frame
	public void Update () {
        // Do nothing
    }

    IEnumerator MoveToPoint() {
        // Make sure rotation is kept on ground
        while ( !player.grav.IsGrounded( ) ) {
            yield return null;
        }

        // Set new point to grounded position
        Vector3 groundedPos = player.rotationPoint;
        groundedPos.y = player.transform.position.y;
        player.rotationPoint = groundedPos;

        // Move character to point of rotation
        while ( Vector3.Distance( player.transform.position, player.rotationPoint ) > 0.1f ) {
            HorizontalMovement( );
            yield return null;
        }

        player.transform.position = player.rotationPoint;
        player.GetComponent<Rigidbody>( ).velocity = new Vector3( 0, 0, 0 );

        float targetAngle = player.transform.eulerAngles.y;
        targetAngle -= 90;
        Quaternion targetRotation = Quaternion.identity;
        targetRotation = Quaternion.Euler( 0.0f, targetAngle, 0.0f );

        // Rotate the player
        while (!QuaternionsEqual(player.transform.rotation, targetRotation)) {
            player.transform.rotation = Quaternion.RotateTowards( player.transform.rotation, targetRotation, 4 * Time.deltaTime );
            yield return null;
        }
        player.transform.rotation = targetRotation;

        player.currentRotation = PositionStates.Rotation.one;
        // Move player to outside of trigger area
        Vector3 targetPosition = player.transform.position;
        targetPosition.z += 6;
        while ( Vector3.Distance( player.transform.position, targetPosition ) > 0.1f ) {
        Debug.Log( "Got here" );
            HorizontalMovement( );
            yield return null;
        }

        SwitchToPlayerMovement( );
    }

    public void FixedUpdate( ) {
        player.StartStateCoroutine( MoveToPoint() );
    }

    public void OnTriggerEnter( Collider other ) {
        // Do nothing
    }

    public void SwitchToRotation( ) {
        // Can't switch to same state
    }

    public void SwitchToPlayerMovement( ) {
        player.currentState = player.playerInput;
    }

    private void HorizontalMovement() {
        // Horizontal movement
        float horVel = (int)player.lastDirection * player.speedUpFactor;
        if ( player.currentRotation == PositionStates.Rotation.zero )
            player.GetComponent<Rigidbody>( ).velocity = new Vector3( horVel, player.GetComponent<Rigidbody>( ).velocity.y, 0 );
        else if ( player.currentRotation == PositionStates.Rotation.one )
            player.GetComponent<Rigidbody>( ).velocity = new Vector3( 0, player.GetComponent<Rigidbody>( ).velocity.y, horVel );
        else if ( player.currentRotation == PositionStates.Rotation.two )
            player.GetComponent<Rigidbody>( ).velocity = new Vector3( -horVel, player.GetComponent<Rigidbody>( ).velocity.y, 0 );
        else if ( player.currentRotation == PositionStates.Rotation.three )
            player.GetComponent<Rigidbody>( ).velocity = new Vector3( 0, player.GetComponent<Rigidbody>( ).velocity.y, -horVel );
    }

    private bool QuaternionsEqual( Quaternion q1, Quaternion q2 ) {
        return (q1.Equals( q2 ) || (q1 == q2));
    }
}
