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
        player.StartStateCoroutine( MoveToPoint() );
        if (player.transform.position == player.rotationPoint)
            SwitchToPlayerMovement( );
    }

    IEnumerator MoveToPoint() {
        while ( player.transform.position != player.rotationPoint ) {
            player.transform.position = Vector3.MoveTowards( player.transform.position, player.rotationPoint, .5f * Time.deltaTime );
            yield return null;
        }
    }

    public void FixedUpdate( ) {
        // Do nothing
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
}
