using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class PlatformerCharacter2D : MonoBehaviour
    {
        public float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
        public float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
        public LayerMask whatIsGround;

        private Animator m_Anim; 
        private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
        const float k_GroundedRadius = .4f; // Radius of the overlap circle to determine if grounded
        private bool m_Grounded;            // Whether or not the player is grounded.

        private Rigidbody2D m_Rigidbody2D;

        private void Awake()
        {
            m_GroundCheck = transform.Find("GroundCheck");
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            m_Anim = GetComponent<Animator>(); 
        }


        public void Update()
        {
            m_Anim.SetFloat("Speed", Mathf.Abs(m_Rigidbody2D.velocity.x));

        }

        private void FixedUpdate()
        {
            m_Grounded = false;

            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, whatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    //Debug.Log(colliders[i].gameObject.name);
                    m_Grounded = true;
                }

                //Debug.Log(m_Grounded); 
            }
        }


        public void Move(float move, bool crouch, bool jump)
        {
            // Move the character
            m_Rigidbody2D.velocity = new Vector2(move*m_MaxSpeed, m_Rigidbody2D.velocity.y);

            // If the player should jump...
            if (m_Grounded && jump)
            {
                // Add a vertical force to the player.
                m_Grounded = false;
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce) );

            }
        }
    }
}
