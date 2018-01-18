using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( Gravity ) )]
[RequireComponent( typeof( PlayerCollision ) )]
public class CharacterMovement : MonoBehaviour {
    #region Variables
    // Variables for movement
    [Tooltip( "Multiplier for how fast character may travel." )]
    public float speedUpFactor = 5;
    [Tooltip( "The curve of character speed from start to top speed. (End at 1,1)" )]
    public AnimationCurve speedUpRatio;
    [Tooltip( "How many seconds it takes to reach top speed." )]
    public float timeToSpeedUp = 2.0f;
    [HideInInspector]
    public float timerSpeedUp = 0.0f;

    [HideInInspector]
    public float horSpeed = 0.0f;

    [HideInInspector]
    public bool turnAround;

    // Variables for turning points
    [HideInInspector]
    public Vector3 rotationPoint;
    [HideInInspector]
    public float rotationAdd;
    [HideInInspector]
    public PositionStates.Rotation endingRotation;
    [HideInInspector]
    public PositionStates.Direction endingDirection;

    // Direction character is moving in and for slowdown
    [HideInInspector]
    public PositionStates.Direction currDirection = PositionStates.Direction.right;
    [HideInInspector]
    public PositionStates.Direction lastDirection = PositionStates.Direction.right;

    // Used for Jumping
    [Tooltip( "How fast the character jumps in the air." )]
    public float jumpSpeed = 50.0f;

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
    }

    void Start( ) {
        currentRotation = PositionStates.Rotation.zero;
        PositionStates.GetConstraints( gameObject, currentRotation );

        grav = GetComponent<Gravity>( );
        coll = GetComponent<PlayerCollision>( );

        turnAround = false;

        currentState = playerInput;
    }


    //--------------------------------------------------------------------------------------------------//
    //-----------------------------------------STATE FUNCTIONS------------------------------------------//
    //--------------------------------------------------------------------------------------------------//
    void Update( ) {
        currentState.Update( );
        if ( currDirection != PositionStates.Direction.idle ) {
            if ( currDirection == PositionStates.Direction.right ) {
                transform.localScale = new Vector3( Mathf.Abs( transform.localScale.x ), transform.localScale.y, transform.localScale.z );
            } else {
                transform.localScale = new Vector3( Mathf.Abs( transform.localScale.x ) * -1, transform.localScale.y, transform.localScale.z );
            }
        }
    }

    void FixedUpdate( ) {
        currentState.FixedUpdate( );
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
    /// Gets the current direction the player is moving in
    /// </summary>
    public void GetDirection( ) {
        // Get integer value for direction character is moving
        if ( Input.GetKey( KeyCode.D ) && !coll.RightCollided( ) ) {
            currDirection = PositionStates.Direction.right;
        } else if ( Input.GetKey( KeyCode.A ) && !coll.LeftCollided( ) ) {
            currDirection = PositionStates.Direction.left;
        } else {
            currDirection = PositionStates.Direction.idle;
        }
    }

    /// <summary>
    /// Determines the horizontal velocity for the player
    /// </summary>
    /// <returns>Float value to be used in setting velocity</returns>
    private float GetHorizontalVelocity( ) {
        // Character is moving
        if ( currDirection != PositionStates.Direction.idle ) {
            if ( currDirection != lastDirection && timerSpeedUp > (timeToSpeedUp * (.5f)) ) {
                // Slowing down when turning around
                turnAround = true;
            }

            if ( turnAround ) {
                if ( currDirection == PositionStates.Direction.right ) {
                    horSpeed += .5f;
                    if ( horSpeed > 0 ) {
                        turnAround = false;
                    }
                } else {
                    horSpeed -= .5f;
                    if ( horSpeed < 0 ) {
                        turnAround = false;
                    }
                }
            } else {
                timerSpeedUp += Time.deltaTime;

                // Make sure timer doesn't go above or below max and min time
                if ( timerSpeedUp > timeToSpeedUp )
                    timerSpeedUp = timeToSpeedUp;

                horSpeed = (int)currDirection * speedUpRatio.Evaluate( timerSpeedUp / timeToSpeedUp ) * speedUpFactor;
            }
            if ( !turnAround )
                lastDirection = currDirection;  // Used for slowing down
        } else { // slow character down
            turnAround = false;
            if ( lastDirection == PositionStates.Direction.right && horSpeed > 0 ) {
                horSpeed -= 0.45f;
                if ( horSpeed <= 0 ) {
                    horSpeed = 0;
                    timerSpeedUp = 0;
                }
            } else if ( lastDirection == PositionStates.Direction.left && horSpeed < 0 ) {
                horSpeed += 0.45f;
                if ( horSpeed >= 0 ) {
                    horSpeed = 0;
                    timerSpeedUp = 0;
                }
            }
        }

        return horSpeed;
    }

    /// <summary>
    /// Sets the current velocity of the character
    /// </summary>
    public void SetHorizontalMovement( ) {
        float horVel = GetHorizontalVelocity( );
        if ( currentRotation == PositionStates.Rotation.zero )
            GetComponent<Rigidbody>( ).velocity = new Vector3( horVel, GetComponent<Rigidbody>( ).velocity.y, 0 );
        else if ( currentRotation == PositionStates.Rotation.one )
            GetComponent<Rigidbody>( ).velocity = new Vector3( 0, GetComponent<Rigidbody>( ).velocity.y, horVel );
        else if ( currentRotation == PositionStates.Rotation.two )
            GetComponent<Rigidbody>( ).velocity = new Vector3( -horVel, GetComponent<Rigidbody>( ).velocity.y, 0 );
        else if ( currentRotation == PositionStates.Rotation.three )
            GetComponent<Rigidbody>( ).velocity = new Vector3( 0, GetComponent<Rigidbody>( ).velocity.y, -horVel );
    }

    /// <summary>
    /// Automatically moves player based on direction
    /// </summary>
    /// <param name="dir">Direction of horizontal movement</param>
    public void SetHorizontalMovement( PositionStates.Direction dir ) {
        float horVel = (int)dir * speedUpFactor;
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
        if ( !grav.IsGrounded( ) ) {
            grav.StartGravity( );
        }
    }

    /// <summary>
    /// Make the character jump
    /// </summary>
    public void Jumping( ) {
        if ( Input.GetKeyDown( KeyCode.Space ) && grav.IsGrounded( ) ) {
            GetComponent<Rigidbody>( ).velocity = new Vector3( GetComponent<Rigidbody>( ).velocity.x,
                jumpSpeed, GetComponent<Rigidbody>( ).velocity.z );
        }
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
}
