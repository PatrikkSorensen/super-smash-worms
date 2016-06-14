using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    public AudioClip clip; 

    protected AudioSource m_AudioSource;

    protected virtual void Awake()
    {
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
