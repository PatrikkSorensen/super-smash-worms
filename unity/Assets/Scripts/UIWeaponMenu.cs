using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class UIWeaponMenu : MonoBehaviour {


    private Animator m_anim;
    private bool m_visible; 

	// Use this for initialization
	void Awake () {
        m_anim = GetComponent<Animator>();
        m_visible = false; 

    }
	
    public void ToggleMenu() {
        if (!m_visible)
        {
            m_anim.SetTrigger("FadeIn");
            m_visible = true;
        } else
        {
            m_anim.SetTrigger("FadeOut");
            m_visible = false;
        } 
    }
}
