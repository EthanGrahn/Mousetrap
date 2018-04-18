using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( CharacterJump ) )]
[RequireComponent( typeof( PlayerCollision ) )]
[RequireComponent( typeof( CharacterDirections ) )]
[RequireComponent( typeof( CharacterControls ) )]
public class CharacterMovement : MonoBehaviour {
    #region Variables
    // Variables for movement
    [Tooltip( "Multiplier for how fast character may travel." )]
    public float speedFactor = 5;
    private float speedCoeff = 1;
    private float extForce = 0;

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
    [SerializeField]
    private LayerMask[] groundLayers;
    [HideInInspector]
    public LayerMask m_whatIsGround;

    // Used for Climbing
    [Tooltip( "How fast the character climbs on walls." )]
    public float climbSpeed = 10.0f;

    // Used for Physics
    [HideInInspector]
    public PositionStates.Rotation currentRotation;
    [HideInInspector]
    public CharacterJump grav;
    [HideInInspector]
    public PlayerCollision coll;
    [HideInInspector]
    public Transform groundCheck;

    private CapsuleCollider _collider;

    // Character States ##################################
    [HideInInspector]
    public CharacterStates currentState;
    // ###################################################
    [HideInInspector]
    public PlayerInput playerInput;
    [HideInInspector]
    public Climbing climbing;
    // ###################################################

    // Camera reference
    public Camera mainCam;
    private CamFollowObject camFollow;

    public ValueFalloff extForceFalloff;

    // coroutine queue
    protected Queue<int> coroutineQueue = new Queue<int>( );
    #endregion

    //--------------------------------------------------------------------------------------------------//
    //------------------------------------------INITIALIZATION------------------------------------------//
    //--------------------------------------------------------------------------------------------------//
    void Awake( ) {
        currentRotation = PositionStates.Rotation.xPos;
        _collider = GetComponent<CapsuleCollider>();
        camFollow = mainCam.GetComponent<CamFollowObject>();

        playerInput = new PlayerInput( this );
        climbing = new Climbing( this );

        foreach (LayerMask l in groundLayers)
        {
            m_whatIsGround = m_whatIsGround | l;
        }

        directions = GetComponent<CharacterDirections>( );
        controller = GetComponent<CharacterControls>( );

        groundCheck = transform.Find( "GroundCheck" );

        extForceFalloff.valueChangeEvent.AddListener(ExternalForceUpdate);
    }

    void Start( ) {
        PositionStates.GetConstraints( gameObject, currentRotation );

        grav = GetComponent<CharacterJump>( );
        coll = GetComponent<PlayerCollision>( );

        currentState = playerInput;
    }


    //--------------------------------------------------------------------------------------------------//
    //-----------------------------------------STATE FUNCTIONS------------------------------------------//
    //--------------------------------------------------------------------------------------------------//
    void Update( ) {
        currentState.Update( );
        if (grav.IsGrounded(groundCheck, m_whatIsGround))
            GetComponent<Animator>().speed = GetComponent<Rigidbody>().velocity.magnitude / 10f;
    }

    void FixedUpdate( ) {
        currentState.FixedUpdate( );
    }

    void ExternalForceUpdate(float value)
    {
        extForce = value;
    }

    void OnTriggerEnter( Collider other ) {
        currentState.OnTriggerEnter( other );
        if ( other.tag == "Web" ) {
            speedCoeff = 0.5f;
        }
    }

    private void OnTriggerExit( Collider other ) {
        currentState.OnTriggerExit( other );
        if ( other.tag == "Web" ) {
            speedCoeff = 1.0f;
        }
    }

    private void OnTriggerStay( Collider other ) {
        currentState.OnTriggerStay( other );
        if ( other.CompareTag( "CamManip" ) && other.GetComponent<CameraZone>().cameraState != camFollow.cameraState
          && other.GetComponent<CameraZone>().WithinBounds(_collider)) {
            camFollow.UpdateCameraState(other.GetComponent<CameraZone>().cameraState);
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
            GetComponent<Rigidbody>( ).velocity = new Vector3( horVel + extForce, yvel, 0.0f );
        else if ( currentRotation == PositionStates.Rotation.zPos )
            GetComponent<Rigidbody>( ).velocity = new Vector3( 0.0f, yvel, horVel + extForce );
        else if ( currentRotation == PositionStates.Rotation.xNeg )
            GetComponent<Rigidbody>( ).velocity = new Vector3( -horVel + extForce, yvel, 0.0f );
        else if ( currentRotation == PositionStates.Rotation.zNeg )
            GetComponent<Rigidbody>( ).velocity = new Vector3( 0.0f, yvel, -horVel + extForce );
    }

    /// <summary>
    /// Make the character jump
    /// </summary>
    public void Jumping( ) {
        if (grav.IsGrounded( groundCheck, m_whatIsGround ) ) {
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
    /// Sets the new plane of rotation and movement for the character.
    /// </summary>
    /// <param name="newRot">New rotation of character movement.</param>
    /// <param name="rPosition">Position of the rotation point.</param>
    public void RotatePlane( PositionStates.Rotation newRot, Vector3 rPosition, float degrees ) {
        Vector3 tmpVel = GetComponent<Rigidbody>( ).velocity;
        GetComponent<Rigidbody>( ).velocity = Vector3.zero;

        currentRotation = newRot;
        StartCoroutine( RotateObject( gameObject.transform, degrees, .5f, true ) );
        StartCoroutine( RotateObject( mainCam.transform, degrees, 1.0f, false ) );
        MoveFromRot( newRot, rPosition );
        GetComponent<Rigidbody>( ).velocity = new Vector3( tmpVel.z, tmpVel.y, tmpVel.x ); // swap x and z velocities
        GetConstraints( );
    }

    /// <summary>
    /// Rotate object around its y axis
    /// </summary>
    /// <param name="obj">Object to rotate's transform</param>
    /// <param name="degrees">How many degrees to rotate object</param>
    /// <param name="totalTime">Total time it should take to rotate object</param>
    /// <param name="isPlayer">If the object is the player and needs new constraints</param>
    IEnumerator RotateObject( Transform obj, float degrees, float totalTime, bool isPlayer ) {
        int myCoroutineFrame = Time.frameCount;
        coroutineQueue.Enqueue( myCoroutineFrame );

        while ( coroutineQueue.Peek( ) != myCoroutineFrame ) {
            yield return null;
        }

        float objRotation = obj.rotation.eulerAngles.y;

        if ( isPlayer )
            GetComponent<Rigidbody>( ).constraints =
                RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        float rate = Mathf.Abs( degrees ) / totalTime;
        float mult = rate;
        if ( degrees < 0 )
            mult *= -1;

        for ( float i = 0.0f; i < Mathf.Abs( degrees ); i += Time.deltaTime * rate ) {
            obj.Rotate( 0, mult * Time.deltaTime, 0, Space.Self );
            yield return null;
        }

        obj.rotation = Quaternion.Euler( 0.0f, Mathf.Round( (objRotation + degrees) % 360 ), 0.0f );
        coroutineQueue.Dequeue( );
    }

    /// <summary>
    /// Move the player from the point of rotation
    /// </summary>
    /// <param name="newRot">Ending rotation of the character</param>
    /// <param name="rPosition">Position of the rotation point</param>
    private void MoveFromRot( PositionStates.Rotation newRot, Vector3 rPosition ) {
        if ( newRot == PositionStates.Rotation.xPos )
            if ( directions.currDirection == PositionStates.Direction.right )
                transform.position = new Vector3( rPosition.x + 0.5f, transform.position.y, rPosition.z );
            else
                transform.position = new Vector3( rPosition.x - 0.5f, transform.position.y, rPosition.z );
        else if ( newRot == PositionStates.Rotation.xNeg )
            if ( directions.currDirection == PositionStates.Direction.right )
                transform.position = new Vector3( rPosition.x - 0.5f, transform.position.y, rPosition.z );
            else
                transform.position = new Vector3( rPosition.x + 0.5f, transform.position.y, rPosition.z );
        else if ( newRot == PositionStates.Rotation.zPos )
            if ( directions.currDirection == PositionStates.Direction.right )
                transform.position = new Vector3( rPosition.x, transform.position.y, rPosition.z + 0.5f );
            else
                transform.position = new Vector3( rPosition.x, transform.position.y, rPosition.z - 0.5f );
        else if ( newRot == PositionStates.Rotation.zNeg )
            if ( directions.currDirection == PositionStates.Direction.right )
                transform.position = new Vector3( rPosition.x, transform.position.y, rPosition.z - 0.5f );
            else
                transform.position = new Vector3( rPosition.x, transform.position.y, rPosition.z + 0.5f );
    }
}
