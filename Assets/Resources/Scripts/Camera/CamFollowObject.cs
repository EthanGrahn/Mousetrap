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

    // Use this for initialization
    void Start () {
        GetComponent<Transform>().position = objToFollow.GetComponent<Transform>().position;

        script = objToFollow.GetComponent<MouseMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        // Get most recent position of object
		objPos = objToFollow.GetComponent<Transform>().position;

        // Move towards object
        // Check if object is player
        if (script != null) {
            currentRotation = script.currentRotation;
            // Check for current rotation of player
            if (script.currentRotation == Rotation.unturned) {
                GetComponent<Transform>().position = Vector3.MoveTowards(GetComponent<Transform>().position,
                    new Vector3(objToFollow.GetComponent<Transform>().position.x,
                        objToFollow.GetComponent<Transform>().position.y,
                        distFromObj),
                    speed * Time.deltaTime);
            } else {
                GetComponent<Transform>().position = Vector3.MoveTowards(GetComponent<Transform>().position,
                    new Vector3(distFromObj,
                        objToFollow.GetComponent<Transform>().position.y,
                        objToFollow.GetComponent<Transform>().position.z),
                    speed * Time.deltaTime);
            }
        } else {    // Object is not player
            // Check rotation of object
            if (currentRotation == Rotation.unturned) {
                GetComponent<Transform>().position = Vector3.MoveTowards(GetComponent<Transform>().position, 
                    new Vector3(objToFollow.GetComponent<Transform>().position.x,
                        objToFollow.GetComponent<Transform>().position.y,
                        distFromObj),
                    speed * Time.deltaTime);
            } else {
                GetComponent<Transform>().position = Vector3.MoveTowards(GetComponent<Transform>().position,
                    new Vector3(distFromObj,
                        objToFollow.GetComponent<Transform>().position.y,
                        objToFollow.GetComponent<Transform>().position.z),
                    speed * Time.deltaTime);
            }
        }
    }
}
