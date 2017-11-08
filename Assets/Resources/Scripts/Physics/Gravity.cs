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

    float termVel;

    // Use this for initialization
    void Start( ) {
        // Calculate terminal velocity
<<<<<<< Updated upstream
        pArea = Mathf.Pow( GetComponent<RectTransform>().sizeDelta.x, 2.0f );
        density = 0.084f;

        termVel = Mathf.Sqrt( (2 * GetComponent<Rigidbody>().mass * Physics.gravity.y) / (density * pArea * dCoeff) );

        // Distance from object to ground
        distToGround = GetComponent<Collider>().bounds.extents.y;
        distToSide = GetComponent<Collider>().bounds.extents.x;
=======
        pArea = Mathf.Pow( GetComponent<RectTransform>( ).sizeDelta.x, 2.0f );
        density = 0.084f;

        termVel = Mathf.Sqrt( (2 * GetComponent<Rigidbody>( ).mass * Physics.gravity.y) / (density * pArea * dCoeff) );

        // Distance from object to ground
        distToGround = GetComponent<Collider>( ).bounds.extents.y;
>>>>>>> Stashed changes
    }

    /// <summary>
    /// Check if the player is on the ground
    /// </summary>
    /// <returns>
    /// Boolean representing grounded status
    /// </returns>
    public bool IsGrounded( ) {
        return Physics.Raycast( transform.position, -transform.up, distToGround + 0.1f );
<<<<<<< Updated upstream
    }

    public bool RightGrounded( ) {
        return Physics.Raycast( transform.position, transform.right, distToSide + .1f ) ||
            Physics.Raycast( transform.position + new Vector3( 0, distToGround, 0 ), transform.right, distToSide + .1f ) ||
            Physics.Raycast( transform.position + new Vector3( 0, (-distToGround + .01f), 0 ), transform.right, distToSide + .1f );
    }

    public bool LeftGrounded( ) {
        return Physics.Raycast( transform.position, -transform.right, distToSide + .1f ) ||
            Physics.Raycast( transform.position + new Vector3( 0, distToGround, 0 ), -transform.right, distToSide + .1f ) ||
            Physics.Raycast( transform.position + new Vector3( 0, (-distToGround + .01f), 0 ), -transform.right, distToSide + .1f );
=======
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
        Vector3 vel = GetComponent<Rigidbody>().velocity;
        vel.y -= 9.81f * Time.deltaTime;
        Mathf.Clamp( vel.y, termVel, -termVel );
        GetComponent<Rigidbody>().velocity = vel;
=======
        Vector3 vel = GetComponent<Rigidbody>( ).velocity;
        vel.y -= 9.81f * Time.deltaTime;
        Mathf.Clamp( vel.y, termVel, -termVel );
        GetComponent<Rigidbody>( ).velocity = vel;
>>>>>>> Stashed changes
        yield return null;
    }
}
