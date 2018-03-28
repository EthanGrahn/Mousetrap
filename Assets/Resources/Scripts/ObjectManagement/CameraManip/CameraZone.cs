using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZone : MonoBehaviour {

    // Object camera will follow and its position
    [Tooltip( "Object that the camera will follow." )]
    public GameObject objToFollow = null;

    [Space( 10 )]

    // Movement speed of camera
    [Tooltip( "How fast camera will move to player when close." )]
    public float speed = -1;

    [Space( 10 )]

    // How far camera looks from object
    [Tooltip( "How far camera will look in front of object. (Depending on which direction they move in)" )]
    public float camViewInFront = -1;
    [Tooltip( "How far camera will look above object." )]
    public float camViewAbove = -1;

    [Space( 10 )]

    // How far object must move before camera follows
    [Tooltip( "Minimum distance object must move in horizontal direction before camera follows." )]
    public float minMoveDistHor = -1;
    [Tooltip( "Minimum distance object must move in vertical direction before camera follows." )]
    public float minMoveDistVer = -1;

    [Space(10)]

    // Clamping camera movement
    // Max distance allowed from object
    [Tooltip( "Distance camera is from object." )]
    public float distFromObj = -1;
    public float timeToUpdate = -1;

	public CameraState cameraState;

    private void Start() {
        CameraState camState = GameObject.Find("Main Camera").GetComponent<CamFollowObject>().cameraState;
        if (distFromObj == -1) distFromObj = camState.distFromObj;
        if (timeToUpdate == -1) timeToUpdate = camState.timeToUpdate;
        if (speed == -1) speed = camState.speed;
        if (objToFollow == null) objToFollow = camState.objToFollow;
        if (minMoveDistHor == -1) minMoveDistHor = camState.minMoveDistHor;
        if (minMoveDistVer == -1) minMoveDistVer = camState.minMoveDistVer;
        if (camViewAbove == -1) camViewAbove = camState.camViewAbove;
        if (camViewInFront == -1) camViewInFront = camState.camViewInFront;

		cameraState = new CameraState(objToFollow, speed, camViewInFront, camViewAbove, 
		                              minMoveDistHor, minMoveDistVer, distFromObj, timeToUpdate);
    }

    /// <summary>
    /// Check if the specified collider is within the bounds of this camera volume.
    /// </summary>
    /// <param name="other">Other object's collider.</param>
    /// <returns></returns>
    public bool WithinBounds(Collider other)
    {
        Collider _collider = GetComponent<BoxCollider>();
        Vector3 boundPoint1 = other.bounds.min;
        Vector3 boundPoint2 = other.bounds.max;
        Vector3 boundPoint3 = new Vector3(boundPoint1.x, boundPoint1.y, boundPoint2.z);
        Vector3 boundPoint4 = new Vector3(boundPoint1.x, boundPoint2.y, boundPoint1.z);
        Vector3 boundPoint5 = new Vector3(boundPoint2.x, boundPoint1.y, boundPoint1.z);
        Vector3 boundPoint6 = new Vector3(boundPoint1.x, boundPoint2.y, boundPoint2.z);
        Vector3 boundPoint7 = new Vector3(boundPoint2.x, boundPoint1.y, boundPoint2.z);
        Vector3 boundPoint8 = new Vector3(boundPoint2.x, boundPoint2.y, boundPoint1.z);
        
        return _collider.bounds.Contains(boundPoint1) && _collider.bounds.Contains(boundPoint2) && _collider.bounds.Contains(boundPoint3) &&
               _collider.bounds.Contains(boundPoint4) && _collider.bounds.Contains(boundPoint5) && _collider.bounds.Contains(boundPoint6) &&
               _collider.bounds.Contains(boundPoint7) && _collider.bounds.Contains(boundPoint8);
    }
}
