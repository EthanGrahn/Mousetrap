using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( Gravity ) )]
[RequireComponent( typeof( PlayerCollision ) )]
[RequireComponent( typeof( CharacterDirections ) )]
[RequireComponent( typeof( CharacterControls ) )]
public class CharacterMovement : MonoBehaviour {
    #region Variables
    // Variables for movement
    [Tooltip( "Multiplier for how fast character may travel." )]
    public float speedFactor = 5;
    private float speedCoeff = 1;

    // Variables for turning points
    [HideInInspector]
    public Vector3 rotationPoint;
    [HideInInspector]
    public float rotationAdd;
    [HideInInspector]
    public PositionStates.Rotation endingRotation;
    [HideInInspector]
    public PositionStates.Direction endingDirection;
    [HideInInspector]
    public bool rotation = false;
    float inTime = 1.2f;

    // Script to determine current moving direction of player
    [HideInInspector]
    public CharacterDirections directions;

    // Determine what actions the player wants to complete
    [HideInInspector]
    public CharacterControls controller;

    // Used for Jumping
    [Tooltip( "How fast the character jumps in the air." )]
    public float jumpSpeed = 10f;

    // Used for Climbing
    [Tooltip( "How fast the character climbs on walls." )]
    public float climbSpeed = 10.0f;

    // Used for Physics
    [HideInInspector]
    public PositionStates.Rotation currentRotation;
    [HideInInspector]
    public Gravity grav;
    [HideInInspector]
    public PlayerCollision coll;
    [HideInInspector]
    public Transform groundCheck;

    // Character States ##################################
    [HideInInspector]
    public CharacterStates currentState;
    // ###################################################
    [HideInInspector]
    public PlayerInput playerInput;
    [HideInInspector]
    public PlayerRotation playerRotation;
    [HideInInspector]
    public Climbing climbing;
    // ###################################################

    // Camera reference
    public Camera mainCam;
    #endregion

    //--------------------------------------------------------------------------------------------------//
    //------------------------------------------INITIALIZATION------------------------------------------//
    //--------------------------------------------------------------------------------------------------//
    void Awake( ) {
        playerInput = new PlayerInput( this );
        playerRotation = new PlayerRotation( this );
        climbing = new Climbing( this );

        directions = GetComponent<CharacterDirections>( );
        controller = GetComponent<CharacterControls>( );

        groundCheck = transform.Find( "GroundCheck" );
    }

    void Start( ) {
        currentRotation = PositionStates.Rotation.xPos;
        PositionStates.GetConstraints( gameObject, currentRotation );

        grav = GetComponent<Gravity>( );
        coll = GetComponent<PlayerCollision>( );

        currentState = playerInput;
    }


    //--------------------------------------------------------------------------------------------------//
    //-----------------------------------------STATE FUNCTIONS------------------------------------------//
    //--------------------------------------------------------------------------------------------------//
    void Update( ) {
        currentState.Update( );
    }

    void FixedUpdate( ) {
        currentState.FixedUpdate( );

        //// If crouching, check to see if the character can stand up
        //if ( !Crouch ) {
        //    // If the character has a ceiling preventing them from standing up, keep them crouching
        //    if ( Physics2D.OverlapCircle( m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround ) ) {
        //        Crouch = true;
        //    }
        //}
    }

    void OnTriggerEnter( Collider other ) {
        currentState.OnTriggerEnter( other );
        if ( other.tag == "Web" ) {
            speedCoeff = .5f;
        }
    }

    private void OnTriggerExit( Collider other ) {
        currentState.OnTriggerExit( other );
        if ( other.tag == "Web" ) {
            speedCoeff = 1.0f;
        }
    }

    public void StartStateCoroutine( IEnumerator routine ) {
        StartCoroutine( routine );
    }


    //--------------------------------------------------------------------------------------------------//
    //-----------------------------------------HELPER FUNCTIONS-----------------------------------------//
    //--------------------------------------------------------------------------------------------------//

    /// <summary>
    /// Automatically moves player based on direction
    /// </summary>
    /// <param name="dir">Direction of horizontal movement</param>
    public void SetHorizontalMovement( PositionStates.Direction dir ) {
        float yvel = GetComponent<Rigidbody>( ).velocity.y;
        float horVel = (int)dir * speedFactor * speedCoeff;
        if ( currentRotation == PositionStates.Rotation.xPos )
            GetComponent<Rigidbody>( ).velocity = new Vector3( horVel, yvel, 0.0f );
        else if ( currentRotation == PositionStates.Rotation.zPos )
            GetComponent<Rigidbody>( ).velocity = new Vector3( 0.0f, yvel, horVel );
        else if ( currentRotation == PositionStates.Rotation.xNeg )
            GetComponent<Rigidbody>( ).velocity = new Vector3( -horVel, yvel, 0.0f );
        else if ( currentRotation == PositionStates.Rotation.zNeg )
            GetComponent<Rigidbody>( ).velocity = new Vector3( 0.0f, yvel, -horVel );
    }

    /// <summary>
    /// Squares Unity's gravity constant
    /// </summary>
    public void Falling( ) {
        if ( !grav.IsGrounded( groundCheck ) ) {
            grav.StartGravity( );
        }
    }

    /// <summary>
    /// Make the character jump
    /// </summary>
    public void Jumping( ) {
        if ( controller.Jump && grav.IsGrounded( groundCheck ) ) {
            GetComponent<Rigidbody>( ).AddForce( new Vector3( 0f, jumpSpeed, 0f ), ForceMode.VelocityChange );
        }
    }

    /// <summary>
    /// Constrains the movement and rotation of the character in certain axes.
    /// </summary>
    public void GetConstraints( ) {
        if ( currentRotation == PositionStates.Rotation.xPos ||
            currentRotation == PositionStates.Rotation.xNeg )
            GetComponent<Rigidbody>( ).constraints =
                RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
        else
            GetComponent<Rigidbody>( ).constraints =
                RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX;
    }

    /// <summary>
    /// Set rotation point, direction of rotation, and ending direction to leave rotation point from for the character.
    /// </summary>
    /// <param name="other">Collider that triggers the rotation to occur</param>
    //public void SetRotationVars( Collider other ) {
    //    rotationAdd = (int)other.GetComponent<RotationVars>( ).rotationDir;
    //    endingRotation = other.GetComponent<RotationVars>( ).endingRotation;
    //    endingDirection = other.GetComponent<RotationVars>( ).endingDirection;
    //    Vector3 point = other.transform.parent.transform.position;
    //    rotationPoint = new Vector3( point.x, transform.position.y, point.z );
    //}

    //private void RotateCharacters( ) {

    //    // Rotate the player
    //    GetComponent<Rigidbody>( ).constraints =
    //        RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    //    float targetAngle = transform.eulerAngles.y;
    //    targetAngle += rotationAdd % 360;
    //    Quaternion targetRotation = Quaternion.identity;
    //    targetRotation = Quaternion.Euler( 0.0f, targetAngle, 0.0f );

    //    for ( float t = 0f; t < 1; t += Time.deltaTime / inTime ) {
    //        transform.rotation = Quaternion.Lerp( transform.rotation, targetRotation, t );
    //    }
    //    PositionStates.GetConstraints( gameObject, currentRotation );
    //    rotation = false;
    //}

    /// <summary>
    /// Sets the new plane of rotation and movement for the character.
    /// </summary>
    /// <param name="newRot">New rotation of character movement.</param>
    /// <param name="rPosition">Position of the rotation point.</param>
    public void RotatePlane( PositionStates.Rotation newRot, Vector3 rPosition ) {
        // Rotate the camera
        float cameraAngle = mainCam.transform.eulerAngles.y;
        cameraAngle += rotationAdd % 360;
        Quaternion cameraRotation = Quaternion.identity;
        cameraRotation = Quaternion.Euler( 0.0f, cameraAngle, 0.0f );

        currentRotation = endingRotation;

        for ( float t = 0f; t < 1; t += Time.deltaTime / inTime ) {
            mainCam.transform.rotation = Quaternion.Lerp( mainCam.transform.rotation, cameraRotation, t );
            Debug.Log( "Rotating camera." );
        }

        mainCam.transform.rotation = cameraRotation;

        Vector3 tmpVel = GetComponent<Rigidbody>( ).velocity;
        GetComponent<Rigidbody>( ).velocity = Vector3.zero;

        currentRotation = newRot;
        if ( newRot == PositionStates.Rotation.xPos )
            if ( directions.currDirection == PositionStates.Direction.right )
                transform.position = new Vector3( rPosition.x + 0.01f, transform.position.y, rPosition.z );
            else
                transform.position = new Vector3( rPosition.x - 0.01f, transform.position.y, rPosition.z );
        else if ( newRot == PositionStates.Rotation.xNeg )
            if ( directions.currDirection == PositionStates.Direction.right )
                transform.position = new Vector3( rPosition.x - 0.01f, transform.position.y, rPosition.z );
            else
                transform.position = new Vector3( rPosition.x + 0.01f, transform.position.y, rPosition.z );
        else if ( newRot == PositionStates.Rotation.zPos )
            if ( directions.currDirection == PositionStates.Direction.right )
                transform.position = new Vector3( rPosition.x, transform.position.y, rPosition.z + 0.01f );
            else
                transform.position = new Vector3( rPosition.x, transform.position.y, rPosition.z - 0.01f );
        else if ( newRot == PositionStates.Rotation.zNeg )
            if ( directions.currDirection == PositionStates.Direction.right )
                transform.position = new Vector3( rPosition.x, transform.position.y, rPosition.z - 0.01f );
            else
                transform.position = new Vector3( rPosition.x, transform.position.y, rPosition.z + 0.01f );
        //rotAlignment = new Vector2(rPosition.x, rPosition.z);
        GetComponent<Rigidbody>( ).velocity = new Vector3( tmpVel.z, tmpVel.y, tmpVel.x ); // swap x and z velocities
        GetConstraints( );
    }
}
