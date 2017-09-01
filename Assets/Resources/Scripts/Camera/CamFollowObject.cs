using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowObject : MonoBehaviour {

    // Object camera will follow and its position
    [SerializeField]
    [Tooltip("Object that the camera will follow.")]
    private GameObject objToFollow;
    private Vector3 objPos;

    // Clamping camera movement
    [SerializeField]
    [Tooltip("Max distance camera can be from player in x direction. (Used for z when player is turned)")]
    private float maxObjDistX;
    [SerializeField]
    [Tooltip("Max distance camera can be from player in y direction.")]
    private float maxObjDistY;
    [SerializeField]
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
    [SerializeField]
    [Tooltip("Distance camera is from object.")]
    private float distFromObj;

    // Movement speed of camera
    [SerializeField]
    [Tooltip("How fast camera will move to player when close.")]
    private float speed;

    // Check if the object is player character
    private MouseMovement script;

    // Current rotation of object
    [SerializeField]
    [Tooltip("Used to follow object in x or z position. Not used when object is player.")]
    private Rotation currentRotation;

    // Set starting position of camera
    void Start () {
        // Used to check if object is player character
        script = objToFollow.GetComponent<MouseMovement>();
        
        Vector3 startPos = objToFollow.GetComponent<Transform>().position;

        // Check if player character
        if ( script != null ) {
            if ( script.currentRotation == Rotation.unturned ) {
                startPos.z -= 10;
            } else {
                startPos.x -= 10;
            }
        } else {    // Not player character
            if ( currentRotation == Rotation.unturned ) {
                startPos.z -= 10;
            } else {
                startPos.x -= 10;
            }
        }

        GetComponent<Transform>().position = startPos;

	}
	
	// Update is called once per frame
	void Update () {
        // Get most recent position of object
		objPos = objToFollow.GetComponent<Transform>().localPosition;

        // Current position of camera
        Vector3 origin = GetComponent<Transform>().localPosition;
        
        // Check if object is player
        if (script != null) {
            // Check for current rotation of player and keep distance from player
            if ( script.currentRotation == Rotation.unturned ) {
                objPos.z -= distFromObj;
            } else {
                objPos.x -= distFromObj;
            }
        } else {    // Not player character
            // Check for current rotation of object and keep distance from object
            if ( currentRotation == Rotation.unturned ) {
                objPos.z -= distFromObj;
            } else {
                objPos.x -= distFromObj;
            }
        }

        // Move the camera
        GetComponent<Transform>().position = Vector3.Lerp( origin, objPos, speed * Time.deltaTime );

        // Clamp camera position
        Vector3 cameraPos = GetComponent<Transform>().position;

        // Close to object
        cameraPos.x = Mathf.Clamp( cameraPos.x, objPos.x - maxObjDistX, objPos.x + maxObjDistX );
        cameraPos.y = Mathf.Clamp( cameraPos.y, objPos.y - maxObjDistX, objPos.y + maxObjDistX );

        // Maximum world distances
        cameraPos.x = Mathf.Clamp( cameraPos.x, minWorldDistX, maxWorldDistX );
        cameraPos.y = Mathf.Clamp( cameraPos.y, minWorldDistY, maxWorldDistY );

        GetComponent<Transform>().position = cameraPos;
    }
}
