using System;
using UnityEngine;

namespace CharacterController
{
    [RequireComponent(typeof (PlatformerCharacter))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter m_Character;
        private bool m_Jump;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = Input.GetKeyDown( KeyCode.Space );
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftShift);

            float h = 0;
            if (Input.GetKey("d"))
                h = 1;
            else if (Input.GetKey("a"))
                h = -1;

            float v = 0;
            if (Input.GetKey("w"))
                v = 1;
            else if (Input.GetKey("s"))
                v = -1;

            // Pass all parameters to the character control script.
            m_Character.Move(h, v, crouch, m_Jump);
            m_Jump = false;
        }
    }
}
