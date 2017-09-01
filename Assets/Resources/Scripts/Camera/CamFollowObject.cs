using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowObject : MonoBehaviour {

    // Object camera will follow and its position
    [SerializeField]
    [Tooltip("Object that the camera will follow.")]
    private GameObject objToFollow;
    private Vector3 objPos;

    // Movement speed of camera
    [SerializeField]
    [Tooltip("How fast camera will move to player when close.")]
    private float speed;

    // How far object must move before camera follows
    [SerializeField]
    [Tooltip( "Minimum distance object must move in horizontal direction before camera follows." )]
    private float minMoveDistX;
    [SerializeField]
    [Tooltip( "Minimum distance object must move in vertical direction before camera follows." )]
    private float minMoveDistY;

    // Clamping camera movement
    // Max distance allowed from object
    [SerializeField]
    [Tooltip( "Distance camera is from object." )]
    private float distFromObj;
    // Close to object
    [SerializeField]
    [Tooltip("Max distance camera can be from player in horizontal direction.")]
    private float maxObjDistHor;
    [SerializeField]
    [Tooltip("Max distance camera can be from player in vertical direction.")]
    private float maxObjDistVer;
    [SerializeField]
    // Within world bounds
    [Tooltip("Max distance camera can be travel in scene in x direction.")]
    private float maxWorldDistX;
    [SerializeField]
    [Tooltip("Min distance camera can be travel in scene in x direction.")]
    private float minWorldDistX;
    [SerializeField]
    [Tooltip("Max distance camera can be travel in scene in y direction.")]
    private float maxWorldDistY;
    [SerializeField]
    [Tooltip("Min distance camera can be travel in scene in y direction.")]
    private float minWorldDistY;
    [SerializeField]
    [Tooltip("Max distance camera can be travel in scene in z direction.")]
    private float maxWorldDistZ;
    [SerializeField]
    [Tooltip("Min distance camera can be travel in scene in z direction.")]
    private float minWorldDistZ;

    // Check if the object is player character
    // Use current rotation of character
    private MouseMovement script;

    // Else use set rotation of object
    [SerializeField]
    [Tooltip("Used to follow object in x or z position. Not used when object is player.")]
    private Rotation currentRotation;

    // Set starting position of camera
    void Start () {
        // Used to check if object is player character
        script = objToFollow.GetComponent<MouseMovement>();
        
        Vector3 startPos = objToFollow.GetComponent<Transform>().position;

        // Check if player character
        if ( (script != null && script.currentRotation == Rotation.unturned) ||
                currentRotation == Rotation.unturned ) {
            startPos.z -= 10;
        } else {    // Not player character
            startPos.x -= 10;
        }

        GetComponent<Transform>().position = startPos;
	}
	
	// Update is called once per frame
	void Update () {
        // Get most recent position of object
		objPos = objToFollow.GetComponent<Transform>().localPosition;

        // Current position of camera
        Vector3 origin = GetComponent<Transform>().localPosition;
        
        // Check if object is player,
        // Check current rotation,
        // Set disance from player
        if ( (script != null && script.currentRotation == Rotation.unturned) ||
                currentRotation == Rotation.unturned ) {
            objPos.z -= distFromObj;
        } else {    // Not player character
            objPos.x -= distFromObj;
        }

        // Move the camera
        GetComponent<Transform>().position = Vector3.Lerp( origin, objPos, speed * Time.deltaTime );

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
            cameraPos.x = Mathf.Clamp( cameraPos.x, objPos.x - maxObjDistHor, objPos.x + maxObjDistHor );
        } else {
            cameraPos.z = Mathf.Clamp( cameraPos.z, objPos.z - maxObjDistHor, objPos.z + maxObjDistHor );
        }
        cameraPos.y = Mathf.Clamp( cameraPos.y, objPos.y - maxObjDistVer, objPos.y + maxObjDistVer );

        // Clamp to world
        cameraPos.x = Mathf.Clamp( cameraPos.x, minWorldDistX, maxWorldDistX );
        cameraPos.y = Mathf.Clamp( cameraPos.y, minWorldDistY, maxWorldDistY );
        cameraPos.z = Mathf.Clamp( cameraPos.z, minWorldDistZ, maxWorldDistZ );

        return cameraPos;
    }
}
