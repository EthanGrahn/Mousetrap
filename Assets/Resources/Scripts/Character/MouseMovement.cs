using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ---------------SHOULD PROBABLY MOVE THIS TO SEPARATE SCRIPT----------------//
// Current rotation
[HideInInspector]
public enum Rotation {unturned = 0, turned = 90};

[RequireComponent(typeof(Gravity))]
public class MouseMovement : MonoBehaviour {

    // Variables for movement
    [SerializeField]
    [Tooltip("Multiplier for how fast character may travel.")]
    private float speedUp = 5;
    [SerializeField]
    [Tooltip("Multiplier for how fast character may slow to a stop.")]
    private float slowDown = 5;
    [SerializeField]
    [Tooltip("The curve of character speed from start to top speed. (End at 1,1)")]
    private AnimationCurve speedUpFactor;
    [SerializeField]
    [Tooltip("The curve of character speed from top speed to stopped. (End at 1,0)")]
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

    [HideInInspector]
    public Rotation currentRotation;

    private Gravity grav;

	// Use this for initialization
	void Start () {
        // Set initial rotation of character
        currentRotation = Rotation.unturned;

        grav = GetComponent<Gravity>();
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
        if ( Input.GetAxisRaw("Vertical") > 0 && grav.IsGrounded() ) {
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, jumpSpeed, GetComponent<Rigidbody>().velocity.z);
        }

        // Falling
        if ( !grav.IsGrounded() ) {
            grav.StartGravity();
        }

        // Lock the x-rotation of the character
        transform.eulerAngles = new Vector3(0, (float)currentRotation, 0);
    }
}
