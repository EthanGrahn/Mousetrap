using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : CharacterStates {
    
    // Update is called once per frame
    void Update( ) {
        // Get integer value for direction character is moving
        if ( Rebind.GetInput( "Right" ) ) {
            currDirection = GlobalVars.Direction.right;
        } else if ( Rebind.GetInput( "Left" ) ) {
            currDirection = GlobalVars.Direction.left;
        } else {
            currDirection = GlobalVars.Direction.idle;
        }

        // Lock the x-rotation of the character
        transform.eulerAngles = new Vector3( 0, (float)currentRotation, 0 );
    }

    void FixedUpdate( ) {
        // Horizontal movement
        float horVel = GetHorizontalVelocity( );
        if ( currentRotation == GlobalVars.Rotation.zero )
            GetComponent<Rigidbody>( ).velocity = new Vector3( horVel, GetComponent<Rigidbody>( ).velocity.y, 0 );
        else if ( currentRotation == GlobalVars.Rotation.one )
            GetComponent<Rigidbody>( ).velocity = new Vector3( 0, GetComponent<Rigidbody>( ).velocity.y, -horVel );
        else if ( currentRotation == GlobalVars.Rotation.two )
            GetComponent<Rigidbody>( ).velocity = new Vector3( -horVel, GetComponent<Rigidbody>( ).velocity.y, 0 );
        else if ( currentRotation == GlobalVars.Rotation.three )
            GetComponent<Rigidbody>( ).velocity = new Vector3( 0, GetComponent<Rigidbody>( ).velocity.y, horVel );

        // Jumping
        if ( Rebind.GetInputDown( "Up" ) && grav.IsGrounded( ) ) {
            GetComponent<Rigidbody>( ).velocity = new Vector3( GetComponent<Rigidbody>( ).velocity.x, jumpSpeed, GetComponent<Rigidbody>( ).velocity.z );
        }

        // Falling
        if ( !grav.IsGrounded( ) ) {
            grav.StartGravity( );
        }
    }

    /// <summary>
    /// Determines the horizontal velocity for the player
    /// </summary>
    /// <returns>Float value to be used in setting velocity</returns>
    private float GetHorizontalVelocity( ) {
        // Character is moving
        if ( currDirection != GlobalVars.Direction.idle ) {
            if ( currDirection != lastDirection && timerSpeedUp > (timeToSpeedUp * (.5f)) ) {
                // Slowing down when turning around
                turnAround = true;
            }

            if ( turnAround ) {
                if ( currDirection == GlobalVars.Direction.right ) {
                    horSpeed += .5f;
                    if ( horSpeed > 1 ) {
                        turnAround = false;
                    }
                } else {
                    horSpeed -= .5f;
                    if ( horSpeed < -1 ) {
                        turnAround = false;
                    }
                }
            } else {
                timerSpeedUp += Time.deltaTime;

                // Make sure timer doesn't go above or below max and min time
                if ( timerSpeedUp > timeToSpeedUp )
                    timerSpeedUp = timeToSpeedUp;

                horSpeed = (int)currDirection * speedUpRatio.Evaluate( timerSpeedUp / timeToSpeedUp ) * speedUpFactor;
            }

            lastDirection = currDirection;  // Used for slowing down
        } else { // slow character down
            if ( lastDirection == GlobalVars.Direction.right && horSpeed > 0 ) {
                horSpeed -= 0.45f;
                if ( horSpeed <= 0 ) {
                    horSpeed = 0;
                    timerSpeedUp = 0;
                }
            } else if ( lastDirection == GlobalVars.Direction.left && horSpeed < 0 ) {
                horSpeed += 0.45f;
                if ( horSpeed >= 0 ) {
                    horSpeed = 0;
                    timerSpeedUp = 0;
                }
            }
        }

        return horSpeed;
    }
}
