using UnityEngine;
using System.Collections;

[RequireComponent (typeof(PlayerCharacter))]
public class PlayerController : MonoBehaviour {

    [HideInInspector]
    public Weapon m_weapon;

    private PlayerCharacter m_Character;
    private bool m_Jump;
    private UIWeaponMenu m_menu;



    private void Start()
    {
        m_Character = GetComponent<PlayerCharacter>();
        m_menu = GameObject.FindObjectOfType<UIWeaponMenu>();
        m_weapon = m_menu.GetCurrentWeapon(); 
    }


    private void Update()
    {
        if (!m_Jump)
            m_Jump = Input.GetButtonDown("Jump");

        if (Input.GetMouseButtonDown(0))
            m_weapon.Shoot();

        if (Input.GetKeyDown(KeyCode.X))
            m_menu.ToggleMenu();

    }


    private void FixedUpdate()
    {
        // Read the inputs.
        bool crouch = Input.GetKey(KeyCode.LeftControl);
        float h = Input.GetAxis("Horizontal");

        // Pass all parameters to the character control script.
        m_Character.Move(h, crouch, m_Jump);
        m_Jump = false;
    }
}
