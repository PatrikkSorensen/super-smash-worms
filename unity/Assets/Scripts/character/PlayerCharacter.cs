using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour {

    public float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
    public float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
    public LayerMask whatIsGround;
    public float m_GroundCheckDistance;

    private Animator m_Anim;
    private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
    const float k_GroundedRadius = .4f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded;            // Whether or not the player is grounded.

    private Rigidbody m_Rigidbody;


    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Anim = GetComponent<Animator>();
    }

    public void Move(float move, bool crouch, bool jump)
    {
        // Move the character
        m_Rigidbody.velocity = new Vector2(move * m_MaxSpeed, m_Rigidbody.velocity.y);
        CheckGroundStatus();

        // If the player should jump...
        if (m_Grounded && jump)
        {
            // Add a vertical force to the player.
            m_Grounded = false;
            m_Rigidbody.AddForce(new Vector2(0f, m_JumpForce));

        }
    }

    void CheckGroundStatus()
    {
        RaycastHit hitInfo;
        Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * m_GroundCheckDistance));

        if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, m_GroundCheckDistance))
        {
            m_Grounded = true;
        }
        else
        {
            m_Grounded = false;
        }

    }
}

