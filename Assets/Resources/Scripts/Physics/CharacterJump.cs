using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour {

	private Rigidbody rb;
	private CharacterControls controller;
	private Vector3 newVelocity = Vector3.zero;
	private bool changeVelocity = false;

	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 2;

	void Start() {
		rb = GetComponent<Rigidbody>();
		controller = GetComponent<CharacterControls>();
	}

	void Update() {

	}

	void FixedUpdate() {
		if (rb.velocity.y < -0.01f) {
			//Debug.Log("1");
			rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
		} else if (rb.velocity.y > 0.01f && !controller.JumpHeld) {
			//Debug.Log("2");
			rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
		}
	}

    /// <summary>
    /// Check if the player is on the ground
    /// </summary>
    /// <returns>
    /// Boolean representing grounded status
    /// </returns>
    /// <param name="groundPos">Object's ground Position</param>
    public bool IsGrounded( Transform groundPos ) {
        Collider[] colliders = Physics.OverlapSphere( groundPos.position, .04f );

        for ( int i = 0; i < colliders.Length; ++i ) {
            if ( colliders[i].gameObject != gameObject )
                return true;
        }
        return false;
    }

    public bool IsGrounded( Transform groundPos, LayerMask lMask ) {
        Collider[] colliders = Physics.OverlapSphere( groundPos.position, .04f, lMask );

        for ( int i = 0; i < colliders.Length; ++i ) {
            if ( colliders[i].gameObject != gameObject )
                return true;
        }

        return false;
    }
}
