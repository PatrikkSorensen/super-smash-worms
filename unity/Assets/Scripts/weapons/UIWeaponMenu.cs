using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;
using System;

[RequireComponent(typeof(Animator))]
public class UIWeaponMenu : MonoBehaviour {

    public GameObject m_arm;

    private GameObject m_player;
    private Animator m_menuAnim;
    private PlayerController m_playerController;

    private Weapon m_currWeapon; 
    private GunBehaviour m_gunBehav;
    private RLauncherBehaviour m_rBehav;



    private bool m_visible;

	void Awake () {
        m_menuAnim = GetComponent<Animator>();
        m_visible = false;
        m_player = GameObject.FindGameObjectWithTag("Player");
        m_playerController = m_player.GetComponent<PlayerController>(); 

        m_gunBehav = GameObject.FindObjectOfType<GunBehaviour>();
        m_rBehav = GameObject.FindObjectOfType<RLauncherBehaviour>();

        // Default weapon: 
        m_currWeapon = m_gunBehav; 

    }
	
    public void ToggleMenu() {
        if (!m_visible)
        {
            m_menuAnim.SetTrigger("FadeIn");
            m_visible = true;
        } else
        {
            m_menuAnim.SetTrigger("FadeOut");
            m_visible = false;
        } 
    }

    public Weapon GetCurrentWeapon()
    {
        return m_currWeapon;
    }

    public void SwitchToGun() {
        m_playerController.m_weapon = m_gunBehav;
        m_playerController.m_weapon.ArmWeapon(); 
    }

    public void SwitchToRocketLauncher()
    {
        m_playerController.m_weapon = m_rBehav;
        m_playerController.m_weapon.ArmWeapon();
    }
}
