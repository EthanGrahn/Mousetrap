using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines properties of an object able to be moved.
/// </summary>
[RequireComponent( typeof( ObjectProperties ) )]
[RequireComponent( typeof( ObjectCollision ) )]
[RequireComponent( typeof( Rigidbody ) )]
public class Movable : MonoBehaviour {

    public float forceMultiplier = 8;

    private ObjectCollision coll;
    public PositionStates.Rotation currRotation;

    void Start( ) {
        PositionStates.GetConstraintsRot( gameObject, currRotation );

        coll = GetComponent<ObjectCollision>( );
    }

    private void FixedUpdate( ) {
        bool move = !(coll.RightCollided( ) && coll.LeftCollided( ));
        UpdateMovability( move );
    }

    /// <summary>
    /// Update the Object Property component value of movability.
    /// </summary>
    /// <param name="movable">Is this object movable?</param>
    void UpdateMovability( bool movable ) {
        int value = 0;
        if ( movable )
            value = 1;
        GetComponent<ObjectProperties>( ).SetProperty( "movable", value.ToString( ) );
    }
}
