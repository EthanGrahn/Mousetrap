using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ---------------SHOULD PROBABLY MOVE THESE TO SEPARATE SCRIPT----------------//
// Current rotation
[HideInInspector]
public enum Rotation { zero = 0, one = 90, two = 180, three = 270 };
public enum Direction { left = -1, right = 1, idle = 0 };

[RequireComponent(typeof(Gravity))]
public class CharacterMovement : MonoBehaviour {

    // Variables for movement
    [SerializeField]
    [Tooltip("Multiplier for how fast character may travel.")]
    private float speedUpFactor = 5;
    [SerializeField]
    [Tooltip("The curve of character speed from start to top speed. (End at 1,1)")]
    private AnimationCurve speedUpRatio;
    [SerializeField]
    [Tooltip("How many seconds it takes to reach top speed.")]
    private float timeToSpeedUp = 2.0f;
    private float timerSpeedUp = 0.0f;

    private float horSpeed = 0.0f;

    private bool turnAround;
    
    // Direction character is moving in and for slowdown
    private Direction currDirection;
    private Direction lastDirection;

    // Used for Jumping
    [SerializeField]
    [Tooltip("How fast the character jumps in the air.")]
    private float jumpSpeed = 50.0f;

    [HideInInspector]
    public Rotation currentRotation;

    private Gravity grav;

	// Use this for initialization
	void Start () {
        // Set initial rotation of character
        currentRotation = Rotation.zero;

        grav = GetComponent<Gravity>();

        turnAround = false;
    }
	
	// Update is called once per frame
	void Update () {
        // Get integer value for direction character is moving
        if ( Input.GetAxisRaw("Horizontal") > 0 ) {
            currDirection = Direction.right;
        } else if ( Input.GetAxisRaw("Horizontal") < 0 ) {
            currDirection = Direction.left;
        } else {
            currDirection = Direction.idle;
        }

        // Lock the x-rotation of the character
        transform.eulerAngles = new Vector3( 0, (float)currentRotation, 0 );
    }

    void FixedUpdate() {
        // Horizontal movement
        float horVel = GetHorizontalVelocity( );
        if(currentRotation == Rotation.zero)
            GetComponent<Rigidbody>( ).velocity = new Vector3( horVel, GetComponent<Rigidbody>( ).velocity.y, 0 );
        else if (currentRotation == Rotation.one)
            GetComponent<Rigidbody>( ).velocity = new Vector3( 0, GetComponent<Rigidbody>( ).velocity.y, -horVel );
        else if (currentRotation == Rotation.two )
            GetComponent<Rigidbody>( ).velocity = new Vector3( -horVel, GetComponent<Rigidbody>( ).velocity.y, 0 );
        else if (currentRotation == Rotation.three )
            GetComponent<Rigidbody>( ).velocity = new Vector3( 0, GetComponent<Rigidbody>( ).velocity.y, horVel );

        // Jumping
        if ( Input.GetAxisRaw( "Vertical" ) > 0 && grav.IsGrounded( ) ) {
            GetComponent<Rigidbody>( ).velocity = new Vector3( GetComponent<Rigidbody>( ).velocity.x, jumpSpeed, GetComponent<Rigidbody>( ).velocity.z );
        }

        // Falling
        if ( !grav.IsGrounded( ) ) {
            grav.StartGravity( );
        }
    }

    /// <summary>
    /// Determines the horizontal velocity for the player
    /// </summary>
    /// <returns>Float value to be used in setting velocity</returns>
    private float GetHorizontalVelocity() {
        // Character is moving
        if ( currDirection != Direction.idle ) {
            if ( currDirection != lastDirection && timerSpeedUp > (timeToSpeedUp * (.5f)) ) {
                // Slowing down when turning around
                turnAround = true;
            } 
            
            if (turnAround) {
                if (currDirection == Direction.right) {
                    horSpeed += .5f;
                    if (horSpeed > 1) {
                        turnAround = false;
                    }
                } else {
                    horSpeed -= .5f;
                    if ( horSpeed < -1 ) {
                        turnAround = false;
                    }
                }
            }
            else {
                timerSpeedUp += Time.deltaTime;

                // Make sure timer doesn't go above or below max and min time
                if ( timerSpeedUp > timeToSpeedUp )
                    timerSpeedUp = timeToSpeedUp;

                horSpeed = (int)currDirection * speedUpRatio.Evaluate( timerSpeedUp / timeToSpeedUp ) * speedUpFactor;
            }

            lastDirection = currDirection;  // Used for slowing down
        } else { // slow character down
            if ( lastDirection == Direction.right && horSpeed > 0 ) {
                horSpeed -= 0.45f;
                if (horSpeed <= 0) {
                    horSpeed = 0;
                    timerSpeedUp = 0;
                }
            } else if ( lastDirection == Direction.left && horSpeed < 0 ) {
                horSpeed += 0.45f;
                if ( horSpeed >= 0 ) {
                    horSpeed = 0;
                    timerSpeedUp = 0;
                }
            }
        }

        return horSpeed;
    }
}
