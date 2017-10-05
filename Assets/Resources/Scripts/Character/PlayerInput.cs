using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : CharacterStates {
    private readonly CharacterMovement player;

    public PlayerInput ( CharacterMovement characterMovement ) {
        player = characterMovement;
    }
    
    // Update is called once per frame
    public void Update( ) {
        // Get integer value for direction character is moving
        if ( Rebind.GetInput( "Right" ) && !player.grav.RightGrounded() ) {
            player.currDirection = PositionStates.Direction.right;
        } else if ( Rebind.GetInput( "Left" ) && !player.grav.LeftGrounded( ) ) {
            player.currDirection = PositionStates.Direction.left;
        } else {
            player.currDirection = PositionStates.Direction.idle;
        }

        // Lock the x-rotation of the character
        //player.transform.eulerAngles = new Vector3( 0, (float)player.currentRotation, 0 );
    }

    public void FixedUpdate( ) {
        // Horizontal movement
        float horVel = GetHorizontalVelocity( );
        if ( player.currentRotation == PositionStates.Rotation.zero )
            player.GetComponent<Rigidbody>( ).velocity = new Vector3( horVel, player.GetComponent<Rigidbody>( ).velocity.y, 0 );
        else if ( player.currentRotation == PositionStates.Rotation.one )
            player.GetComponent<Rigidbody>( ).velocity = new Vector3( 0, player.GetComponent<Rigidbody>( ).velocity.y, horVel );
        else if ( player.currentRotation == PositionStates.Rotation.two )
            player.GetComponent<Rigidbody>( ).velocity = new Vector3( -horVel, player.GetComponent<Rigidbody>( ).velocity.y, 0 );
        else if ( player.currentRotation == PositionStates.Rotation.three )
            player.GetComponent<Rigidbody>( ).velocity = new Vector3( 0, player.GetComponent<Rigidbody>( ).velocity.y, -horVel );

        // Jumping
        if ( Rebind.GetInputDown( "Up" ) && player.grav.IsGrounded( ) ) {
            player.GetComponent<Rigidbody>( ).velocity = new Vector3( player.GetComponent<Rigidbody>( ).velocity.x,
                player.jumpSpeed, player.GetComponent<Rigidbody>( ).velocity.z );
        }

        // Falling
        if ( !player.grav.IsGrounded( ) ) {
            player.grav.StartGravity( );
        }
    }

    /// <summary>
    /// Determines the horizontal velocity for the player
    /// </summary>
    /// <returns>Float value to be used in setting velocity</returns>
    private float GetHorizontalVelocity( ) {
        // Character is moving
        if ( player.currDirection != PositionStates.Direction.idle ) {
            if ( player.currDirection != player.lastDirection && player.timerSpeedUp > (player.timeToSpeedUp * (.5f)) ) {
                // Slowing down when turning around
                player.turnAround = true;
            }

            if ( player.turnAround ) {
                if ( player.currDirection == PositionStates.Direction.right ) {
                    player.horSpeed += .5f;
                    if ( player.horSpeed > 0 ) {
                        player.turnAround = false;
                    }
                } else {
                    player.horSpeed -= .5f;
                    if ( player.horSpeed < 0 ) {
                        player.turnAround = false;
                    }
                }
            } else {
                player.timerSpeedUp += Time.deltaTime;

                // Make sure timer doesn't go above or below max and min time
                if ( player.timerSpeedUp > player.timeToSpeedUp )
                    player.timerSpeedUp = player.timeToSpeedUp;

                player.horSpeed = (int)player.currDirection * player.speedUpRatio.Evaluate( player.timerSpeedUp / player.timeToSpeedUp ) * player.speedUpFactor;
            }
            if (!player.turnAround)
                player.lastDirection = player.currDirection;  // Used for slowing down
        } else { // slow character down
            player.turnAround = false;
            if ( player.lastDirection == PositionStates.Direction.right && player.horSpeed > 0 ) {
                player.horSpeed -= 0.45f;
                if ( player.horSpeed <= 0 ) {
                    player.horSpeed = 0;
                    player.timerSpeedUp = 0;
                }
            } else if ( player.lastDirection == PositionStates.Direction.left && player.horSpeed < 0 ) {
                player.horSpeed += 0.45f;
                if ( player.horSpeed >= 0 ) {
                    player.horSpeed = 0;
                    player.timerSpeedUp = 0;
                }
            }
        }

        return player.horSpeed;
    }

    public void SwitchToRotation( ) {
        Vector3 vel = new Vector3( 0, player.GetComponent<Rigidbody>( ).velocity.y, 0 );
        player.GetComponent<Rigidbody>( ).velocity = vel;
        player.currentState = player.playerRotation;
    }

    public void SwitchToPlayerMovement( ) {
        // Do nothing, can't switch to same state
    }

    public void SwitchToPlayerCrawl( ) {
        // Need to implement
    }

    public void OnTriggerEnter( Collider other ) {
        if ( other.CompareTag("TriggerRotationSwitch") ) {
            player.rotationAdd = (int)other.GetComponent<RotationVars>( ).rotationDir;
            player.endingRotation = other.GetComponent<RotationVars>( ).endingRotation;
            player.endingDirection = other.GetComponent<RotationVars>( ).endingDirection;
            Vector3 point = other.transform.parent.transform.position;
            player.rotationPoint = new Vector3( point.x, player.transform.position.y, point.z );
            SwitchToRotation( );
        }
        if ( other.CompareTag("TriggerCrawl") ) {
            
        }
    }
}
