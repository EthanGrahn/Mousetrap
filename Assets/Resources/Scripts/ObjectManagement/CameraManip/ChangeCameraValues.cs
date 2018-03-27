using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ChangeCameraValues : MonoBehaviour {

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
    
}
