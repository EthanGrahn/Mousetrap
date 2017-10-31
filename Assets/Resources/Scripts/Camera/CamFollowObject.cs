using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowObject : MonoBehaviour {

    #region Variables
    // Object camera will follow and its position
    [SerializeField]
    [Tooltip( "Object that the camera will follow." )]
    private GameObject objToFollow;
    private Vector3 oldObjPos;
    [Space( 10 )]

    // Movement speed of camera
    [SerializeField]
    [Tooltip( "How fast camera will move to player when close." )]
    private float speed;
    [Space( 10 )]

    // How far camera looks from object
    [SerializeField]
    [Tooltip( "How far camera will look in front of object. (Depending on which direction they move in)" )]
    private float camViewInFront;
    [SerializeField]
    [Tooltip( "How far camera will look above object." )]
    private float camViewAbove;
    [Space( 10 )]


    // How far object must move before camera follows
    [SerializeField]
    [Tooltip( "Minimum distance object must move in horizontal direction before camera follows." )]
    private float minMoveDistHor;
    [SerializeField]
    [Tooltip( "Minimum distance object must move in vertical direction before camera follows." )]
    private float minMoveDistVer;
    [Space( 10 )]

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
    private CharacterMovement script;

    // Else use set rotation of object
    [Space( 10 )]
    [SerializeField]
    [Tooltip( "Used to follow object in x or z position. Not used when object is player." )]
    private PositionStates.Rotation currentRotation;

    // Store direction object is moving
    private PositionStates.Direction currDirection;

    // Other camera variables
    private bool updateCam;
    private Vector3 origin;
    private Vector3 targetPos;
    #endregion

    // Set starting position of camera
    void Start( ) {
        // Set initial position reference of object
        oldObjPos = objToFollow.GetComponent<Transform>().position;

        // Assume object is initially moving to the right
        currDirection = PositionStates.Direction.right;
        // Used to check if object is player character
        script = objToFollow.GetComponent<CharacterMovement>();

        // Set starting position of camera
        Vector3 startPos;
        if ( script != null ) {
            startPos = GetTargetPosition( oldObjPos, script.currentRotation );
        } else {
            startPos = GetTargetPosition( oldObjPos, currentRotation );
        }

        GetComponent<Transform>().position = startPos;

        updateCam = false;
    }

    // Update is called once per frame
    void Update( ) {
        // Get most recent position of followed object
        Vector3 currObjPos = objToFollow.GetComponent<Transform>().position;

        // Get target position for camera
        if ( script != null ) {
            targetPos = GetTargetPosition( currObjPos, script.currentRotation );
        } else {
            targetPos = GetTargetPosition( currObjPos, currentRotation );
        }


        // Get which direction object is moving
        if ( script != null ) {
            currDirection = GetDirection( currObjPos, script.currentRotation );
        } else {
            currDirection = GetDirection( currObjPos, currentRotation );
        }

        // Current position of camera
        origin = GetComponent<Transform>().position;

        // Move the camera
        if ( (Mathf.Abs( origin.x - targetPos.x ) >= minMoveDistHor ||
            Mathf.Abs( origin.y - targetPos.y ) >= minMoveDistVer) ||
            Mathf.Abs( origin.z - targetPos.z ) >= minMoveDistHor && !updateCam ) {
            updateCam = true;
        }


        // Set final camera position
        if ( script != null ) {
            GetComponent<Transform>().position = ClampCameraPosition( targetPos, script.currentRotation );
        } else {
            GetComponent<Transform>().position = ClampCameraPosition( targetPos, currentRotation );
        }
    }

    private void FixedUpdate( ) {
        if ( updateCam ) {
            transform.position = Vector3.Lerp( origin, targetPos, speed * Time.deltaTime );
            // Stop updating camera position when close to target point
            if ( Vector3.Distance( origin, targetPos ) < .1f ) {
                updateCam = false;
            }
        }
    }

    /// <summary>
    /// Keeps the camera within a specified distance close to object, but not outside of determined world size.
    /// </summary>
    /// <param name="target">
    /// Position of object to clamp camera to
    /// </param>
    /// <returns>
    /// Vector 3 position for camera
    /// </returns>
    Vector3 ClampCameraPosition( Vector3 target, PositionStates.Rotation rot ) {
        Vector3 cameraPos = GetComponent<Transform>().position;

        // Check rotation of object
        // Clamp to character

        if ( rot == PositionStates.Rotation.zero ) {
            cameraPos.x = Mathf.Clamp( cameraPos.x, target.x - maxObjDistHor, target.x + maxObjDistHor );
        } else if ( rot == PositionStates.Rotation.one ) {
            cameraPos.z = Mathf.Clamp( cameraPos.z, target.z - maxObjDistHor, target.z + maxObjDistHor );
        } else if ( rot == PositionStates.Rotation.two ) {
            cameraPos.x = Mathf.Clamp( cameraPos.x, target.x - maxObjDistHor, target.x + maxObjDistHor );
        } else if ( rot == PositionStates.Rotation.three ) {
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
    PositionStates.Direction GetDirection( Vector3 objPos, PositionStates.Rotation rot ) {
        // Don't change directions unless moving
        PositionStates.Direction newDir = currDirection;

        // Check for current rotation of object
        if ( rot == PositionStates.Rotation.zero ) {
            // Check where object is moving
            if ( objPos.x < oldObjPos.x - 0.02f ) {
                newDir = PositionStates.Direction.left;
            } else if ( objPos.x > oldObjPos.x + 0.01f ) {
                newDir = PositionStates.Direction.right;
            }
        } else if ( rot == PositionStates.Rotation.one ) {
            // Check where object is moving
            if ( objPos.z < oldObjPos.z - 0.02f ) {
                newDir = PositionStates.Direction.right;
            } else if ( objPos.z > oldObjPos.z ) {
                newDir = PositionStates.Direction.left;
            }
        } else if ( rot == PositionStates.Rotation.two ) {
            // Check where object is moving
            if ( objPos.x < oldObjPos.x - 0.02f ) {
                newDir = PositionStates.Direction.right;
            } else if ( objPos.x > oldObjPos.x + 0.02f ) {
                newDir = PositionStates.Direction.left;
            }
        } else if ( rot == PositionStates.Rotation.three ) {
            // Check where object is moving
            if ( objPos.z < oldObjPos.z - 0.02f ) {
                newDir = PositionStates.Direction.right;
            } else if ( objPos.z > oldObjPos.z ) {
                newDir = PositionStates.Direction.left;
            }
        }

        // Update old position
        oldObjPos = objPos;

        return newDir;
    }

    /// <summary>
    /// Returns a new Vector3 position based upon passed in basePos
    /// </summary>
    /// <param name="basePos">
    /// Starting position for new Vector3 position
    /// </param>
    /// <returns>
    /// Vector3 position
    /// </returns>
    public Vector3 GetTargetPosition( Vector3 basePos, PositionStates.Rotation rot ) {
        Vector3 target = basePos;

        // Check current rotation,
        // Set disance from player
        if ( rot == PositionStates.Rotation.zero ) {
            // Camera position away from object
            target.z -= distFromObj;

            // Camera position in front of object
            if ( currDirection == PositionStates.Direction.right ) {
                target.x += camViewInFront;
            } else {
                target.x -= camViewInFront;
            }
        } else if ( rot == PositionStates.Rotation.one ) {
            // Camera position away from object
            target.x += distFromObj;

            // Camera position in front of object
            if ( currDirection == PositionStates.Direction.right ) {
                target.z -= camViewInFront;
            } else {
                target.z += camViewInFront;
            }
        } else if ( rot == PositionStates.Rotation.two ) {
            // Camera position away from object
            target.z += distFromObj;

            // Camera position in front of object
            if ( currDirection == PositionStates.Direction.right ) {
                target.x -= camViewInFront;
            } else {
                target.x += camViewInFront;
            }
        } else if ( rot == PositionStates.Rotation.three ) {
            // Camera position away from object
            target.x -= distFromObj;

            // Camera position in front of object
            if ( currDirection == PositionStates.Direction.right ) {
                target.z -= camViewInFront;
            } else {
                target.z += camViewInFront;
            }
        }
        target.y += camViewAbove;

        return target;
    }
}
