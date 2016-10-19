using UnityEngine;
using System.Collections;

public class GunProjectile : MonoBehaviour {

    public int bulletDamage = 10;

    private ParticleSystem m_shatterParticles; 

    void Start()
    {
        m_shatterParticles = GetComponentInChildren<ParticleSystem>(); 
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with: " + other.gameObject.name); 
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
