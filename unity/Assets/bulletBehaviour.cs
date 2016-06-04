using UnityEngine;
using System.Collections;

public class bulletBehaviour : MonoBehaviour {

    public int bulletDamage = 10;

    private ParticleSystem m_shatterParticles; 

    void Start()
    {
        m_shatterParticles = GetComponentInChildren<ParticleSystem>(); 
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
         
        if (coll.gameObject.tag == "Enemy")
        {
            StartCoroutine(ShatterBullet()); 
            coll.gameObject.SendMessage("ApplyDamage", bulletDamage);
            
        }
    }

    IEnumerator ShatterBullet()
    {
        m_shatterParticles.Play();

        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject); 
    }
}
