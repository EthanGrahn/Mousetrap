using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZone : MonoBehaviour {

    [SerializeField]
    private bool useObjToFollow = false;
    // Object camera will follow and its position
    [Tooltip( "Object that the camera will follow." )]
    public GameObject objToFollow = null;

    [Space( 10 )]

    [SerializeField]
    private bool useSpeed = false;
    // Movement speed of camera
    [Tooltip( "How fast camera will move to player when close." )]
    public float speed = 0;

    [Space( 10 )]

    [SerializeField]
    private bool useCamViewInFront = false;
    // How far camera looks from object
    [Tooltip( "How far camera will look in front of object. (Depending on which direction they move in)" )]
    public float camViewInFront = 0;
    [SerializeField]
    private bool useCamViewAbove = false;
    [Tooltip( "How far camera will look above object." )]
    public float camViewAbove = 0;

    [Space( 10 )]

    [SerializeField]
    private bool useMinMoveDistHor = false;
    // How far object must move before camera follows
    [Tooltip( "Minimum distance object must move in horizontal direction before camera follows." )]
    public float minMoveDistHor = 0;
    [SerializeField]
    private bool useMinMoveDistVer = false;
    [Tooltip( "Minimum distance object must move in vertical direction before camera follows." )]
    public float minMoveDistVer = 0;

    [Space(10)]

    [SerializeField]
    private bool useDistFromObj = false;
    // Clamping camera movement
    // Max distance allowed from object
    [Tooltip( "Distance camera is from object." )]
    public float distFromObj = 0;
    [SerializeField]
    private bool useTimeToUpdate = false;
    public float timeToUpdate = 0;

	public CameraState cameraState;

    private void Start() {
        CameraState camState = GameObject.Find("Main Camera").GetComponent<CamFollowObject>().cameraState;
        if (!useDistFromObj) distFromObj = camState.distFromObj;
        if (!useTimeToUpdate) timeToUpdate = camState.timeToUpdate;
        if (!useSpeed) speed = camState.speed;
        if (!useObjToFollow) objToFollow = camState.objToFollow;
        if (!useMinMoveDistHor) minMoveDistHor = camState.minMoveDistHor;
        if (!useMinMoveDistVer) minMoveDistVer = camState.minMoveDistVer;
        if (!useCamViewAbove) camViewAbove = camState.camViewAbove;
        if (!useCamViewInFront) camViewInFront = camState.camViewInFront;

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
