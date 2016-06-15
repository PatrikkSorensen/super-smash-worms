using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D; 

[RequireComponent(typeof(Animator))]
public class UIWeaponMenu : MonoBehaviour {

    public GameObject m_arm;

    private GameObject m_player;
    private Animator m_menuAnim;
    private Animator m_armAnim;
    private Platformer2DUserControl m_playerController; 

    private GunBehaviour m_gunBehav;
    private RLauncherBehaviour m_rBehav; 

    private bool m_visible;

	void Awake () {
        m_menuAnim = GetComponent<Animator>();
        m_armAnim = m_arm.GetComponent<Animator>(); 
        m_visible = false;
        m_player = GameObject.FindGameObjectWithTag("Player");
        m_playerController = m_player.GetComponent<Platformer2DUserControl>(); 

        m_gunBehav = m_player.GetComponent<GunBehaviour>();
        m_rBehav = m_player.GetComponent<RLauncherBehaviour>();

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

    public void SwitchToGun() {
        m_playerController.weapon = m_gunBehav;
        m_playerController.weapon.ArmWeapon(); 
        m_armAnim.SetTrigger("pickup_gun");
    }

    public void SwitchToRocketLauncher()
    {
        m_playerController.weapon = m_rBehav;
        m_playerController.weapon.ArmWeapon();
        m_armAnim.SetTrigger("pickup_rocket");
    }
}
