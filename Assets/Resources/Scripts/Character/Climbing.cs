using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : CharacterStates
{
    public CharacterMovement player;
    private int climbing = 0;
    private bool hanging = false;
    private Vector3 hangPos;

    public Climbing(CharacterMovement cMovement)
    {
        player = cMovement;
    }

    // Update is called once per frame
    public void Update()
    {
        // Get integer value for direction character is moving
        if (Rebind.GetInput("Right") && !Physics.Raycast(player.transform.position, player.transform.right, 1))
        {
            player.currDirection = PositionStates.Direction.right;
        }
        else if (Rebind.GetInput("Left") && !Physics.Raycast(player.transform.position, -player.transform.right, 1))
        {
            player.currDirection = PositionStates.Direction.left;
        }
        else
        {
            player.currDirection = PositionStates.Direction.idle;
        }

        if (Rebind.GetInput("Up"))
        {
            hanging = false;
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            climbing = 1;
        }
        else if (Rebind.GetInput("Down"))
        {
            hanging = false;
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            climbing = -1;
        }
        else if (!hanging)
        {
            hanging = true;
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            climbing = 0;
        }

        // Lock the x-rotation of the character
        player.transform.eulerAngles = new Vector3(0, (float)player.currentRotation, 0);
    }

    public void FixedUpdate()
    {
        // Ascending
        if (climbing == 1)
        {
            player.GetComponent<Rigidbody>().velocity = new Vector3(0, player.jumpSpeed / 5, 0);
        }
        // Descending
        else if (climbing == -1)
        {
            player.GetComponent<Rigidbody>().velocity = new Vector3(0, -player.jumpSpeed / 5, 0);
            player.gameObject.GetComponent<Rigidbody>().useGravity = false;

        }
        // Hanging
        else if (climbing == 0)
        {

        }

        // Horizontal movement
        float horVel = GetHorizontalVelocity();
        if (player.currentRotation == PositionStates.Rotation.zero)
            player.GetComponent<Rigidbody>().velocity = new Vector3(horVel, player.GetComponent<Rigidbody>().velocity.y, 0);
        else if (player.currentRotation == PositionStates.Rotation.one)
            player.GetComponent<Rigidbody>().velocity = new Vector3(0, player.GetComponent<Rigidbody>().velocity.y, horVel);
        else if (player.currentRotation == PositionStates.Rotation.two)
            player.GetComponent<Rigidbody>().velocity = new Vector3(-horVel, player.GetComponent<Rigidbody>().velocity.y, 0);
        else if (player.currentRotation == PositionStates.Rotation.three)
            player.GetComponent<Rigidbody>().velocity = new Vector3(0, player.GetComponent<Rigidbody>().velocity.y, -horVel);
    }

    /// <summary>
    /// Determines the horizontal velocity for the player
    /// </summary>
    /// <returns>Float value to be used in setting velocity</returns>
    private float GetHorizontalVelocity()
    {
        // Character is moving
        if (player.currDirection != PositionStates.Direction.idle)
        {
            if (player.currDirection != player.lastDirection && player.timerSpeedUp > (player.timeToSpeedUp * (.5f)))
            {
                // Slowing down when turning around
                player.turnAround = true;
            }

            if (player.turnAround)
            {
                if (player.currDirection == PositionStates.Direction.right)
                {
                    player.horSpeed += .5f;
                    if (player.horSpeed > 0)
                    {
                        player.turnAround = false;
                    }
                }
                else
                {
                    player.horSpeed -= .5f;
                    if (player.horSpeed < 0)
                    {
                        player.turnAround = false;
                    }
                }
            }
            else
            {
                player.timerSpeedUp += Time.deltaTime;

                // Make sure timer doesn't go above or below max and min time
                if (player.timerSpeedUp > player.timeToSpeedUp)
                    player.timerSpeedUp = player.timeToSpeedUp;

                player.horSpeed = (int)player.currDirection * player.speedUpRatio.Evaluate(player.timerSpeedUp / player.timeToSpeedUp) * player.speedUpFactor;
            }
            if (!player.turnAround)
                player.lastDirection = player.currDirection;  // Used for slowing down
        }
        else
        { // slow character down
            player.turnAround = false;
            if (player.lastDirection == PositionStates.Direction.right && player.horSpeed > 0)
            {
                player.horSpeed -= 0.45f;
                if (player.horSpeed <= 0)
                {
                    player.horSpeed = 0;
                    player.timerSpeedUp = 0;
                }
            }
            else if (player.lastDirection == PositionStates.Direction.left && player.horSpeed < 0)
            {
                player.horSpeed += 0.45f;
                if (player.horSpeed >= 0)
                {
                    player.horSpeed = 0;
                    player.timerSpeedUp = 0;
                }
            }
        }

        return player.horSpeed;
    }


    public void SwitchToRotation()
    {

    }

    public void SwitchToPlayerMovement()
    {
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        player.gameObject.GetComponent<Rigidbody>().useGravity = true;
        player.currentState = player.playerInput;
    }

    public void OnTriggerEnter(Collider other)
    {

    }

    public void OnTriggerExit(Collider other)
    {
        SwitchToPlayerMovement();
    }

    public void SwitchToPlayerCrawl( ) {

    }
}
