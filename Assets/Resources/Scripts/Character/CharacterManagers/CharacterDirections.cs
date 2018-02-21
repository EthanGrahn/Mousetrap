using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( CharacterMovement ) )]
public class CharacterDirections : MonoBehaviour {

    // Direction character is moving in and for slowdown
    [HideInInspector]
    public PositionStates.Direction currDirection = PositionStates.Direction.right;
    [HideInInspector]
    public PositionStates.Direction lastDirection = PositionStates.Direction.right;
    [HideInInspector]
    public CharacterMovement player;

    // Used for collisions against a wall
    private PlayerCollision coll;

    private void Start( ) {
        coll = GetComponent<PlayerCollision>( );
        player = GetComponent<CharacterMovement>( );
    }

    private void Update( ) {
        if ( currDirection != PositionStates.Direction.idle ) {
            if ( currDirection == PositionStates.Direction.right ) {
                transform.localScale = new Vector3( Mathf.Abs( transform.localScale.x ),
                    transform.localScale.y, transform.localScale.z );
            } else {
                transform.localScale = new Vector3( Mathf.Abs( transform.localScale.x ) * -1,
                    transform.localScale.y, transform.localScale.z );
            }
        }
    }

    /// <summary>
    /// Gets the current direction the player is moving in
    /// </summary>
    public void GetDirection( ) {
        // Get integer value for direction character is moving
        if ( player.controller.Right ) {
            currDirection = PositionStates.Direction.right;
        } else if ( player.controller.Left ) {
            currDirection = PositionStates.Direction.left;
        } else {
            currDirection = PositionStates.Direction.idle;
        }
    }
}
