using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour {

    // Variables for movement
    [SerializeField]
    [Tooltip("Multiplier for how fast character may travel.")]
    private int speedUp = 5;
    [SerializeField]
    [Tooltip("Multiplier for how fast character may slow to a stop.")]
    private int slowDown = 5;
    [SerializeField]
    [Tooltip("The curve of character speed from start to top speed.")]
    private AnimationCurve speedUpFactor;
    [SerializeField]
    [Tooltip("The curve of character speed from top speed to stopped.")]
    private AnimationCurve slowDownFactor;
    [SerializeField]
    [Tooltip("How many seconds it takes to reach top speed.")]
    private float timeToSpeedUp = 2.0f;
    [SerializeField]
    [Tooltip("How many seconds it takes to stop.")]
    private float timeToSlowDown = 0.5f;
    private float timerSpeedUp = 0.0f;
    private float timerSlowDown = 0.0f;
    
    // Direction character is moving in and for slowdown
    private int direction;
    private int lastDirection;

    // Current direction and speed of character
    private float xSpeed;

    // Used for Jumping
    [SerializeField]
    [Tooltip("How fast the character jumps in the air.")]
    private float jumpSpeed = 50.0f;
    private float distToGround;

    // Current rotation
    enum Rotation {unturned = 0, turned = 90};
    Rotation currentRotation;

	// Use this for initialization
	void Start () {
        // Distance from object to ground
        distToGround = GetComponent<Collider>().bounds.extents.y;

        // Set initial rotation of character
        currentRotation = Rotation.unturned;
    }
	
	// Update is called once per frame
	void Update () {
        // Get integer value for direction character is moving
        if ( Input.GetAxisRaw("Horizontal") > 0 ) {
            direction = (int)Mathf.Ceil(Input.GetAxisRaw("Horizontal"));
        } else if ( Input.GetAxisRaw("Horizontal") < 0 ) {
            direction = (int)Mathf.Floor(Input.GetAxisRaw("Horizontal"));
        } else {
            direction = 0;
        }

        // Character is moving
        if ( direction != 0 ) {
            timerSlowDown = 0;

            if ( direction != lastDirection && timerSpeedUp > (timeToSpeedUp*(.5f)) ) {
                // Slowing down when turning around
                timerSpeedUp = (timeToSpeedUp * (.25f));
            }

            timerSpeedUp += Time.deltaTime;

            // Make sure timer doesn't go above or below max and min time
            if ( timerSpeedUp > timeToSpeedUp)
                timerSpeedUp = timeToSpeedUp;

            xSpeed = direction * speedUpFactor.Evaluate(timerSpeedUp/timeToSpeedUp) * speedUp * Time.deltaTime;

            lastDirection = direction;  // Used for slowing down
        } else {
            timerSpeedUp -= Time.deltaTime;
            if ( timerSlowDown < timeToSlowDown )
                timerSlowDown += Time.deltaTime;

            if ( timerSlowDown >= timeToSlowDown ) {
                timerSlowDown = timeToSlowDown;
                timerSpeedUp = 0;
            }

            xSpeed = lastDirection * slowDownFactor.Evaluate(timerSlowDown / timeToSlowDown) * slowDown * Time.deltaTime;
        }

        transform.position += new Vector3(xSpeed, 0, 0);

        // Jumping
        if ( Input.GetAxisRaw("Vertical") > 0 && IsGrounded() ) {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
        }

        // Lock the x-rotation of the character
        transform.eulerAngles = new Vector3(0, (float)currentRotation, 0);
    }

    /// <summary>
    /// Check if the player is on the ground
    /// </summary>
    /// <returns>
    /// Boolean representing grounded status
    /// </returns>
    bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
}
