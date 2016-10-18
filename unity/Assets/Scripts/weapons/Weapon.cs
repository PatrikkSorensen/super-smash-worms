using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    public AudioClip clip;

    private Transform m_player;
    protected AudioSource m_AudioSource;
    protected Animator m_anim;


    protected virtual void Awake()
    {
        m_player = GameObject.FindGameObjectWithTag("Player").transform; 
        m_anim = m_player.GetComponent<Animator>(); 
        m_AudioSource = GetComponentInChildren<AudioSource>();
    }

    public virtual void Shoot() {
        if(clip)
            m_AudioSource.Play();
    }

    public virtual void ArmWeapon()
    {
        if (clip)
            m_AudioSource.clip = clip; 
    }
}
