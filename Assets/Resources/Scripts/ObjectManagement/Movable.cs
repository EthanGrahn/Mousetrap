using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines properties of an object able to be moved.
/// </summary>
[RequireComponent( typeof( ObjectProperties ) )]
[RequireComponent( typeof( ObjectCollision ) )]
public class Movable : MonoBehaviour {

    public float forceMultiplier = 8;

    private new Rigidbody rigidbody;
    private float startRot;
    private float startPos;

    private ObjectCollision coll;
    public PositionStates.Rotation currRotation;

    /// <summary>
    /// Initialization.
    /// </summary>
    void Start( ) {
        if ( GetComponent<Rigidbody>( ) == null )
            gameObject.AddComponent<Rigidbody>( );

        rigidbody = GetComponent<Rigidbody>( );
        startRot = transform.rotation.eulerAngles.y;

        if ( currRotation == PositionStates.Rotation.zero ||
            currRotation == PositionStates.Rotation.two )
            startPos = transform.position.z;
        else
            startPos = transform.position.x;

        coll = GetComponent<ObjectCollision>( );
    }

    private void FixedUpdate( ) {
        transform.rotation = Quaternion.Euler( transform.rotation.x, startRot, transform.rotation.z );

        if ( currRotation == PositionStates.Rotation.zero ||
            currRotation == PositionStates.Rotation.two )
            transform.position = new Vector3( transform.position.x, transform.position.y, startPos );
        else
            transform.position = new Vector3( startPos, transform.position.y, transform.position.z );

        bool move = coll.RightCollided( ) && coll.LeftCollided( );
        UpdateMovability( move );
    }

    /// <summary>
    /// Update the Object Property component value of movability.
    /// </summary>
    /// <param name="movable">Is this object movable?</param>
    void UpdateMovability( bool movable ) {
        int value = 0;
        if ( !movable )
            value = 1;
        GetComponent<ObjectProperties>( ).SetProperty( "movable", value.ToString( ) );
    }
}
