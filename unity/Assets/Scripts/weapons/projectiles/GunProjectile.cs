using UnityEngine;
using System.Collections;

public class GunProjectile : Projectile {

    

    private ParticleSystem m_shatterParticles; 

    void Start()
    {
        m_shatterParticles = GetComponentInChildren<ParticleSystem>(); 
    }

    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(ShatterBullet());
    }

    IEnumerator ShatterBullet()
    {
        MoveTrail trail = transform.parent.GetComponent<MoveTrail>();
        trail.moveSpeed = 0;
        trail.FadeOutTrail(0.5f); 
        
        m_shatterParticles.Play();
        Destroy(gameObject.GetComponent<BoxCollider>()); 
        yield return new WaitForSeconds(1.0f);
        
    }
}
