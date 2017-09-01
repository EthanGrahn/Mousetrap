using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowObject : MonoBehaviour {

    // Object camera will follow and its position
    [SerializeField]
    [Tooltip( "Object that the camera will follow." )]
    private GameObject objToFollow;
    private Vector3 oldObjPos;

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
        Vector3 currObjPos = objToFollow.GetComponent<Transform>().position;

        // Get target position for camera
        Vector3 targetPos = currObjPos;
        targetPos = GetTargetPosition( targetPos );

        // Get which direction object is moving
        currDirection = GetDirection(currObjPos);

        // Current position of camera
        Vector3 origin = GetComponent<Transform>().position;

        // Move the camera
        if ( origin.x <= targetPos.x - minMoveDistHor || origin.x >= targetPos.x + minMoveDistHor ||
                origin.y <= targetPos.y - minMoveDistVer || origin.y >= targetPos.y + minMoveDistVer ) {
            GetComponent<Transform>().position = Vector3.Lerp( origin, targetPos, speed * Time.deltaTime );
        }

        // Set final camera position
        GetComponent<Transform>().position = ClampCameraPosition( targetPos );
    }

    /// <summary>
    /// Keeps the camera within a specified distance close to object, but not outside of determined world size.
    /// </summary>
    /// <returns>
    /// Vector 3 position for camera
    /// </returns>
    Vector3 ClampCameraPosition( Vector3 target ) {
        Vector3 cameraPos = GetComponent<Transform>().position;

        // Check rotation of object
        // Clamp to character
        if ( (script != null && script.currentRotation == Rotation.unturned) ||
                currentRotation == Rotation.unturned ) {
            cameraPos.x = Mathf.Clamp( cameraPos.x, target.x - maxObjDistHor, target.x + maxObjDistHor );
        } else {
            cameraPos.z = Mathf.Clamp( cameraPos.z, target.z - maxObjDistHor, target.z + maxObjDistHor );
        }
        cameraPos.y = Mathf.Clamp( cameraPos.y, target.y - maxObjDistVer, target.y + maxObjDistVer );

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
    Direction GetDirection( Vector3 objPos ) {
        // Don't change directions unless moving
        Direction newDir = currDirection;

        // Check for current rotation of object
        if ( (script != null && script.currentRotation == Rotation.unturned) ||
                currentRotation == Rotation.unturned ) {
            // Check where object is moving
            if ( objPos.x < oldObjPos.x && newDir == Direction.right ) {
                newDir = Direction.left;
            } else if ( objPos.x > oldObjPos.x && newDir == Direction.left ) {
                newDir = Direction.right;
            }
        } else {
            // Check where object is moving
            if ( objPos.z < oldObjPos.z && newDir == Direction.left ) {
                newDir = Direction.right;
            } else if ( objPos.z > oldObjPos.z && newDir == Direction.right ) {
                newDir = Direction.left;
            }
        }

        // Update old position
        oldObjPos = objPos;

        return newDir;
    }

    Vector3 GetTargetPosition( Vector3 target ) {
        // Check current rotation,
        // Set disance from player
        if ( (script != null && script.currentRotation == Rotation.unturned) ||
                currentRotation == Rotation.unturned ) {
            // Camera position away from player
            target.z -= distFromObj;

            // Camera position in from of character
            if ( currDirection == Direction.right ) {
                target.x += camViewInFront;
            } else {
                target.x -= camViewInFront;
            }
        } else {    // Turned
            target.x -= distFromObj;

            // Camera position in from of character
            if ( currDirection == Direction.right ) {
                target.z -= camViewInFront;
            } else {
                target.z += camViewInFront;
            }
        }
        target.y += camViewAbove;

        return target;
    }
}
