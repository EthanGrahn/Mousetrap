using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

    // Terminal velocity variables
    private float pArea;
    [SerializeField]
    [Tooltip( "Density coefficient of the object." )]
    private float dCoeff;
    private float density;
    [SerializeField]
    [Tooltip( "Volume of the object." )]
    private float volume;

    // Falling object variables
    private float distToGround;
    private float distToSide;

    float termVel;

    // Use this for initialization
    void Start( ) {
        // Calculate terminal velocity
        pArea = Mathf.Pow( GetComponent<RectTransform>( ).sizeDelta.x, 2.0f );
        density = 0.084f;

        termVel = Mathf.Sqrt( (2 * GetComponent<Rigidbody>( ).mass * Physics.gravity.y) / (density * pArea * dCoeff) );

        // Distance from object to ground
        distToGround = GetComponent<Collider>( ).bounds.extents.y;
        distToSide = GetComponent<Collider>( ).bounds.extents.x;
    }

    /// <summary>
    /// Check if the player is on the ground
    /// </summary>
    /// <returns>
    /// Boolean representing grounded status
    /// </returns>
    public bool IsGrounded( ) {
        return Physics.Raycast( transform.position, -transform.up, distToGround + 0.1f );
    }

    /// <summary>
    /// 
    /// </summary>
    public void StartGravity( ) {
        StartCoroutine( "GravityOperate" );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IEnumerator GravityOperate( ) {
        Vector3 vel = GetComponent<Rigidbody>( ).velocity;
        vel.y -= 9.81f * Time.deltaTime;
        Mathf.Clamp( vel.y, termVel, -termVel );
        GetComponent<Rigidbody>( ).velocity = vel;
        yield return null;
    }
}
