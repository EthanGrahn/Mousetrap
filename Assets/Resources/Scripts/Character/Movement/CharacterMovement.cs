using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( Gravity ) )]
[RequireComponent( typeof( PlayerCollision ) )]
[RequireComponent( typeof( CharacterDirections ) )]
public class CharacterMovement : MonoBehaviour {
    #region Variables
    // Variables for movement
    [Tooltip( "Multiplier for how fast character may travel." )]
    public float speedFactor = 5;

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

    // Used for Jumping
    [Tooltip( "How fast the character jumps in the air." )]
    public float jumpSpeed = 100f;

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

        groundCheck = transform.Find( "GroundCheck" );
    }

    void Start( ) {
        currentRotation = PositionStates.Rotation.zero;
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

        if ( rotation )
            RotateCharacters( );

        //Falling( );
    }

    void OnTriggerEnter( Collider other ) {
        currentState.OnTriggerEnter( other );
    }

    private void OnTriggerExit( Collider other ) {
        currentState.OnTriggerExit( other );
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
        float horVel = (int)dir * speedFactor;
        if ( currentRotation == PositionStates.Rotation.zero )
            GetComponent<Rigidbody>( ).velocity = new Vector3( horVel, 0.0f, 0.0f );
        else if ( currentRotation == PositionStates.Rotation.one )
            GetComponent<Rigidbody>( ).velocity = new Vector3( 0.0f, 0.0f, horVel );
        else if ( currentRotation == PositionStates.Rotation.two )
            GetComponent<Rigidbody>( ).velocity = new Vector3( -horVel, 0.0f, 0.0f );
        else if ( currentRotation == PositionStates.Rotation.three )
            GetComponent<Rigidbody>( ).velocity = new Vector3( 0.0f, 0.0f, -horVel );
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
        if ( Input.GetKeyDown( KeyCode.Space ) && grav.IsGrounded( groundCheck ) ) {
            GetComponent<Rigidbody>( ).AddForce( 0f, jumpSpeed, 0f );
        }
    }

    /// <summary>
    /// Constrains the movement and rotation of the character in certain axes.
    /// </summary>
    public void GetConstraints( ) {
        if ( currentRotation == PositionStates.Rotation.zero ||
            currentRotation == PositionStates.Rotation.two )
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
    public void SetRotationVars( Collider other ) {
        rotationAdd = (int)other.GetComponent<RotationVars>( ).rotationDir;
        endingRotation = other.GetComponent<RotationVars>( ).endingRotation;
        endingDirection = other.GetComponent<RotationVars>( ).endingDirection;
        Vector3 point = other.transform.parent.transform.position;
        rotationPoint = new Vector3( point.x, transform.position.y, point.z );
    }

    private void RotateCharacters( ) {
        // Rotate the camera
        float cameraAngle = mainCam.transform.eulerAngles.y;
        cameraAngle += rotationAdd % 360;
        Quaternion cameraRotation = Quaternion.identity;
        cameraRotation = Quaternion.Euler( 0.0f, cameraAngle, 0.0f );

        currentRotation = endingRotation;

        for ( float t = 0f; t < 1; t += Time.deltaTime / inTime ) {
            mainCam.transform.rotation = Quaternion.Lerp( mainCam.transform.rotation, cameraRotation, t );
        }

        mainCam.transform.rotation = cameraRotation;

        // Rotate the player
        GetComponent<Rigidbody>( ).constraints =
            RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        float targetAngle = transform.eulerAngles.y;
        targetAngle += rotationAdd % 360;
        Quaternion targetRotation = Quaternion.identity;
        targetRotation = Quaternion.Euler( 0.0f, targetAngle, 0.0f );

        for ( float t = 0f; t < 1; t += Time.deltaTime / inTime ) {
            transform.rotation = Quaternion.Lerp( transform.rotation, targetRotation, t );
        }
        PositionStates.GetConstraints( gameObject, currentRotation );
        rotation = false;
    }
}
