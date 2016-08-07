using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    public AudioClip clip;
    public Transform player;

    protected AudioSource m_AudioSource;
    protected Animator m_anim;


    protected virtual void Awake()
    {
        m_anim = player.GetComponent<Animator>(); 
        m_AudioSource = GetComponentInChildren<AudioSource>();
    }

    public virtual void Shoot() {
        m_AudioSource.Play();
    }

    public virtual void ArmWeapon()
    {
        m_AudioSource.clip = clip; 
    }
}
