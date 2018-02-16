using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( CharacterMovement ) )]
public class CharacterControls : MonoBehaviour {

    // Movement
    [HideInInspector]
    public bool Right = false;
    [HideInInspector]
    public bool Left = false;

    // Jumping
    [HideInInspector]
    public bool Jump = false;

    // Climbing
    [HideInInspector]
    public bool Up = false;
    [HideInInspector]
    public bool Down = false;

    //public bool Crouch = false;


    // Update is called once per frame
    void Update( ) {
        Right = Input.GetKey( KeyCode.D );
        Left = Input.GetKey( KeyCode.A );

        Jump = Input.GetKey( KeyCode.Space );

        Up = Input.GetKey( KeyCode.W );
        Down = Input.GetKey( KeyCode.S );
    }
}
