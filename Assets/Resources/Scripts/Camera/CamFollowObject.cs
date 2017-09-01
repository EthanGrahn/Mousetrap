using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowObject : MonoBehaviour {

    // Object camera will follow and its position
    [SerializeField]
    [Tooltip( "Object that the camera will follow." )]
    private GameObject objToFollow;
    private Vector3 targetPos;
    private Vector3 oldObjPos;
    private Vector3 currObjPos;

    // Movement speed of camera
    [SerializeField]
    [Tooltip( "How fast camera will move to player when close." )]
    private float speed;

    // How far camera looks from object
    [SerializeField]
    [Tooltip( "How far camera will look in front of object. (Depending on which direction they move in)" )]
    private float camViewInFront;
    [SerializeField]
    [Tooltip( "How far camera will look above object." )]
    private float camViewAbove;


    // How far object must move before camera follows
    [SerializeField]
    [Tooltip( "Minimum distance object must move in horizontal direction before camera follows." )]
    private float minMoveDistHor;
    [SerializeField]
    [Tooltip( "Minimum distance object must move in vertical direction before camera follows." )]
    private float minMoveDistVer;

    // Clamping camera movement
    // Max distance allowed from object
    [SerializeField]
    [Tooltip( "Distance camera is from object." )]
    private float distFromObj;
    // Close to object
    [SerializeField]
    [Tooltip( "Max distance camera can be from player in horizontal direction." )]
    private float maxObjDistHor;
    [SerializeField]
    [Tooltip( "Max distance camera can be from player in vertical direction." )]
    private float maxObjDistVer;
    [SerializeField]
    // Within world bounds
    [Tooltip( "Max distance camera can be travel in scene in x direction." )]
    private float maxWorldDistX;
    [SerializeField]
    [Tooltip( "Min distance camera can be travel in scene in x direction." )]
    private float minWorldDistX;
    [SerializeField]
    [Tooltip( "Max distance camera can be travel in scene in y direction." )]
    private float maxWorldDistY;
    [SerializeField]
    [Tooltip( "Min distance camera can be travel in scene in y direction." )]
    private float minWorldDistY;
    [SerializeField]
    [Tooltip( "Max distance camera can be travel in scene in z direction." )]
    private float maxWorldDistZ;
    [SerializeField]
    [Tooltip( "Min distance camera can be travel in scene in z direction." )]
    private float minWorldDistZ;

    // Check if the object is player character
    // Use current rotation of character
    private MouseMovement script;

    // Else use set rotation of object
    [SerializeField]
    [Tooltip( "Used to follow object in x or z position. Not used when object is player." )]
    private Rotation currentRotation;

    // Store direction object is moving
    enum Direction { left, right };
    private Direction currDirection;

    // Set starting position of camera
    void Start () {
        // Set initial position reference of object
        oldObjPos = objToFollow.GetComponent<Transform>().position;

        // Assume object is initially moving to the right
        currDirection = Direction.right;
        // Used to check if object is player character
        script = objToFollow.GetComponent<MouseMovement>();
        
        Vector3 startPos = objToFollow.GetComponent<Transform>().position;

        // 
        if ( (script != null && script.currentRotation == Rotation.unturned) ||
                currentRotation == Rotation.unturned ) {
            // Camera position away from player
            startPos.z -= distFromObj;
            // Camera position in front of player
            startPos.x += camViewInFront;
        } else {    // Not player character
            // Camera position away from player
            startPos.x -= distFromObj;
            // Camera position in front of player
            startPos.z -= camViewInFront;
        }

        GetComponent<Transform>().position = startPos;
	}
	
	// Update is called once per frame
	void Update () {
        // Get most recent position of followed object
        currObjPos = objToFollow.GetComponent<Transform>().localPosition;

        // Get which direction object is moving
        currDirection = GetDirection();

        // Get target position for camera
        targetPos = objToFollow.GetComponent<Transform>().localPosition;

        // Current position of camera
        Vector3 origin = GetComponent<Transform>().localPosition;
        
        // Check if object is player,
        // Check current rotation,
        // Set disance from player
        if ( (script != null && script.currentRotation == Rotation.unturned) ||
                currentRotation == Rotation.unturned ) {
            // Camera position away from player
            targetPos.z -= distFromObj;
        } else {    // Not player character
            targetPos.x -= distFromObj;
        }

        // Move the camera
        GetComponent<Transform>().position = Vector3.Lerp( origin, targetPos, speed * Time.deltaTime );

        // Set final camera position
        GetComponent<Transform>().position = ClampCameraPosition();
    }

    /// <summary>
    /// Keeps the camera within a specified distance close to object, but not outside of determined world size.
    /// </summary>
    /// <returns>
    /// Vector 3 position for camera
    /// </returns>
    Vector3 ClampCameraPosition() {
        Vector3 cameraPos = GetComponent<Transform>().position;

        // Check rotation of object
        // Clamp to character
        if ( (script != null && script.currentRotation == Rotation.unturned) ||
                currentRotation == Rotation.unturned ) {
            cameraPos.x = Mathf.Clamp( cameraPos.x, targetPos.x - maxObjDistHor, targetPos.x + maxObjDistHor );
        } else {
            cameraPos.z = Mathf.Clamp( cameraPos.z, targetPos.z - maxObjDistHor, targetPos.z + maxObjDistHor );
        }
        cameraPos.y = Mathf.Clamp( cameraPos.y, targetPos.y - maxObjDistVer, targetPos.y + maxObjDistVer );

        // Clamp to world
        cameraPos.x = Mathf.Clamp( cameraPos.x, minWorldDistX, maxWorldDistX );
        cameraPos.y = Mathf.Clamp( cameraPos.y, minWorldDistY, maxWorldDistY );
        cameraPos.z = Mathf.Clamp( cameraPos.z, minWorldDistZ, maxWorldDistZ );

        return cameraPos;
    }

    /// <summary>
    /// Check which direction object is moving in
    /// </summary>
    /// <returns>
    /// Enum containing direction
    /// </returns>
    Direction GetDirection() {
        // Don't change directions unless moving
        Direction newDir = currDirection;

        // Check for current rotation of object
        if ( (script != null && script.currentRotation == Rotation.unturned) ||
                currentRotation == Rotation.unturned ) {
            // Check where object is moving
            if ( currObjPos.x < oldObjPos.x ) {
                newDir = Direction.left;
            } else if ( currObjPos.x > oldObjPos.x ) {
                newDir = Direction.right;
            }
        } else {
            // Check where object is moving
            if ( currObjPos.z < oldObjPos.z ) {
                newDir = Direction.right;
            } else if ( currObjPos.z > oldObjPos.z ) {
                newDir = Direction.left;
            }
        }

        // Update old position
        oldObjPos = currObjPos;

        return newDir;
    }
}
