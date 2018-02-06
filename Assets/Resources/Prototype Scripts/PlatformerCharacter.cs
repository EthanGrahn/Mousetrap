using System;
using UnityEngine;

namespace CharacterController
{
    public class PlatformerCharacter : MonoBehaviour
    {
        [SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
        [SerializeField] private float m_ClimbSpeed = 3f;                   // The fastest the player can travel while climbing
        [SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
        [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
        [SerializeField] private bool m_xPlane = true;                      // Is the player operating in the X plane (else they are in the Z plane)
        [SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
        [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

        private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
        const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
        private bool m_Grounded;            // Whether or not the player is grounded.
        private bool m_isClimbable;         // Whether or not the player is colliding with a climbable object
        private Transform m_CeilingCheck;   // A position marking where to check for ceilings
        const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
        private Rigidbody m_Rigidbody;
        private bool m_FacingRight = true;  // For determining which way the player is currently facing.
        private Vector2 rotAlignment;
        private int isInvert = 1;

        private void Awake()
        {
            // Setting up references.
            m_GroundCheck = transform.Find("GroundCheck");
            m_CeilingCheck = transform.Find("CeilingCheck");
            m_Rigidbody = GetComponent<Rigidbody>();
            rotAlignment = new Vector2(transform.position.x, transform.position.z);
        }


        private void FixedUpdate()
        {
            m_Grounded = false;

            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider[] colliders = Physics.OverlapSphere(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    m_Grounded = true;
                }
            }

            if (m_xPlane)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, rotAlignment.y);
            }
            else
            {
                transform.position = new Vector3(rotAlignment.x, transform.position.y, transform.position.z);
            }
        }

        public void Move(float move, float vertical, bool crouch, bool jump)
        {
            // If crouching, check to see if the character can stand up
            if (!crouch)
            {
                // If the character has a ceiling preventing them from standing up, keep them crouching
                if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
                {
                    crouch = true;
                }
            }

            // If next to climbable object and attempting to climb
            if (m_isClimbable && vertical != 0)
            {                  
                m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, vertical*m_ClimbSpeed, m_Rigidbody.velocity.z);
            }

            //only control the player if grounded or airControl is turned on
            if (m_Grounded || m_AirControl)
            {
                // Reduce the speed if crouching by the crouchSpeed multiplier
                move = (crouch ? move*m_CrouchSpeed : move);

                // Move the character
                if (m_xPlane)
                    m_Rigidbody.velocity = new Vector3(move*m_MaxSpeed*isInvert, m_Rigidbody.velocity.y, m_Rigidbody.velocity.z);
                else
                    m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, m_Rigidbody.velocity.y, move*m_MaxSpeed*isInvert);

                // If the input is moving the player right and the player is facing left...
                if (move > 0 && !m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
                    // Otherwise if the input is moving the player left and the player is facing right...
                else if (move < 0 && m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
            }
            // If the player should jump...
            if (m_Grounded && jump)
            {
                // Add a vertical force to the player.
                m_Grounded = false;
                m_Rigidbody.AddForce(new Vector2(0f, m_JumpForce));
            }
        }

        /// <summary>
        /// Sets the new plane of rotation and movement for the character.
        /// </summary>
        /// <param name="xPlane">Is the new plane on the x axis of the world?</param>
        /// <param name="rPosition">Position of the rotation point.</param>
        public void RotatePlane(bool xPlane, Vector3 rPosition, bool invertAxis)
        {
            Vector3 tmpVel = m_Rigidbody.velocity;
            m_Rigidbody.velocity = Vector3.zero;

            if (invertAxis && isInvert == 1)
                isInvert = -1;
            else if (invertAxis && isInvert == -1)
                isInvert = 1;
                
            transform.position = new Vector3(rPosition.x, transform.position.y, rPosition.z);
            rotAlignment = new Vector2(rPosition.x, rPosition.z);
            m_xPlane = xPlane;
            m_Rigidbody.velocity = new Vector3(tmpVel.z, tmpVel.y, tmpVel.x); // swap x and z velocities
        }

        /// <summary>
        /// Flip the character sprite.
        /// </summary>
        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            m_FacingRight = !m_FacingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Climbable"))
                m_isClimbable = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Climbable"))
                m_isClimbable = false;
        }
    }
}
