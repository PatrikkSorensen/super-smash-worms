using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class UIWeaponMenu : MonoBehaviour {

    public GameObject m_arm;

    private Animator m_menuAnim;
    private Animator m_armAnim; 
    private bool m_visible;

	void Awake () {
        m_menuAnim = GetComponent<Animator>();
        m_armAnim = m_arm.GetComponent<Animator>(); 
        m_visible = false; 

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
        m_armAnim.SetTrigger("pickup_gun"); 
    }

    public void SwitchToRocketLauncher()
    {
        m_armAnim.SetTrigger("pickup_rocket");
    }
}
