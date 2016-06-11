using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    [RequireComponent(typeof(GunBehaviour))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        public GunBehaviour weapon;
        public UIWeaponMenu menu; 

        private PlatformerCharacter2D m_Character;
        private bool m_Jump;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
            menu = GetComponentInChildren<UIWeaponMenu>();
        }


        private void Update()
        {
            if (!m_Jump)
                m_Jump = Input.GetButtonDown("Jump");

            if (Input.GetMouseButtonDown(0))
                weapon.Shoot();

            if (Input.GetKeyDown(KeyCode.X))
                menu.ToggleMenu();

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
}
