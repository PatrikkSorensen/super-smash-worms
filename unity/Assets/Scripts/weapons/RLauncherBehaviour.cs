using UnityEngine;
using System.Collections;

public class RLauncherBehaviour : Weapon
{
    /*
     * 
     * Have a cooldown timer (done in logic)
     * Have smoke from gun 
     * Signify slider for holding down 
     * Trigger animation on fire 
     * Trigger animation on reload (done) 
     * Play sound when cant fire
     */

    public Transform weaponEdge;
    public LayerMask whatToHit;
    public GameObject rocketProjectile;
    public GameObject body; 
    public float speed = 300.0f;
    public float cooldownTimer = 1.0f; 

    private GameObject m_rocket;
    private float m_timeSinceFired = 0.0f;

    override
    public void Shoot() {

        if(Time.time > cooldownTimer + m_timeSinceFired)
        {
            base.Shoot();
            CreateRocket();
            m_anim.SetTrigger("Reload"); 
            m_timeSinceFired = Time.time; 
        } else
        {
            Debug.Log("Cant fire yet!"); 
        }



    }

    override
    public void ArmWeapon()
    {

    }

    void CreateRocket()
    {
        Instantiate(rocketProjectile, weaponEdge.transform.position, weaponEdge.rotation);
    }
}
