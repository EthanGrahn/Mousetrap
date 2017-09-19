using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Gravity))]
public class CharacterMovement : MonoBehaviour {

    // Variables for movement
    [Tooltip("Multiplier for how fast character may travel.")]
    public float speedUpFactor = 5;
    [Tooltip("The curve of character speed from start to top speed. (End at 1,1)")]
    public AnimationCurve speedUpRatio;
    [Tooltip("How many seconds it takes to reach top speed.")]
    public float timeToSpeedUp = 2.0f;
    [HideInInspector]
    public float timerSpeedUp = 0.0f;

    [HideInInspector]
    public float horSpeed = 0.0f;

    [HideInInspector]
    public bool turnAround;
    
    // Direction character is moving in and for slowdown
    [HideInInspector]
    public PositionStates.Direction currDirection = PositionStates.Direction.right;
    [HideInInspector]
    public PositionStates.Direction lastDirection = PositionStates.Direction.right;

    // Used for Jumping
    [Tooltip("How fast the character jumps in the air.")]
    public float jumpSpeed = 50.0f;

    [HideInInspector]
    public PositionStates.Rotation currentRotation;

    [HideInInspector]
    public Gravity grav;

    [HideInInspector]
    public Vector3 rotationPoint;

    [HideInInspector]
    public CharacterStates currentState;
    [HideInInspector]
    public PlayerInput playerInput;
    [HideInInspector]
    public PlayerRotation playerRotation;

    void Awake() {
        playerInput = new PlayerInput( this );
        playerRotation = new PlayerRotation( this );
    }

	// Use this for initialization
	void Start () {
        // Set initial rotation of character
        currentRotation = PositionStates.Rotation.zero;

        grav = GetComponent<Gravity>( );

        turnAround = false;

        currentState = playerInput;
    }
	
	// Update is called once per frame
	void Update () {
        currentState.Update( );
    }

    void FixedUpdate() {
        currentState.FixedUpdate( );
    }

    void OnTriggerEnter( Collider other ) {
        currentState.OnTriggerEnter( other );
    }

    public void StartStateCoroutine(IEnumerator routine) {
        StartCoroutine( routine );
    }
}
