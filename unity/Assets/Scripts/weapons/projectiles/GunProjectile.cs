using UnityEngine;
using System.Collections;

public class GunProjectile : MonoBehaviour {

    public int bulletDamage = 10;

    private ParticleSystem m_shatterParticles; 

    void Start()
    {
        m_shatterParticles = GetComponentInChildren<ParticleSystem>(); 
    }

    void OnCollisionEnter(Collision collision) {
        
        Debug.Log("Hello again..");

        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Hello"); 
            StartCoroutine(ShatterBullet());
            //collision.gameObject.SendMessage("ApplyDamage", bulletDamage);
            
        }
    }

    IEnumerator ShatterBullet()
    {
        m_shatterParticles.Play();
        Destroy(gameObject.GetComponent<BoxCollider>()); 
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject); 
    }
}
