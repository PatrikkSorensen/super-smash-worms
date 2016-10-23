using UnityEngine;
using System.Collections;
using DG.Tweening; 

public class RocketProjectile : Projectile {

    public float timeBeforeDestroyed = 1;
    public float speed = 10.0f;
    public float m_radius = 5.0f;
    public float explosionForce;                
    public LayerMask thingsToExplode; 

    private GameObject m_player;
    private ParticleSystem m_explodeParticles; 
    private AudioSource m_source; 

    void Start() {
        AddForce();
        Destroy(gameObject, timeBeforeDestroyed);
        m_explodeParticles = GetComponentInChildren<ParticleSystem>(); 
        m_source = GetComponent<AudioSource>();
        IgnorePlayerPhysics();

    }

    void AddForce()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.right * speed);
    }

    void OnCollisionEnter(Collision collision)
    { 
        m_source.Play();
        StartCoroutine(ShatterRocket());

        Camera.main.DOShakePosition(0.5f, 1.0f);

        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, m_radius, thingsToExplode);

        foreach (Collider2D m_obj in objects) {
            Rigidbody temp_rb = m_obj.GetComponent<Rigidbody>();

            if (m_obj.gameObject.tag == "Enemy")
                m_obj.gameObject.SendMessage("ApplyDamage", damage);

            if (temp_rb != null) {

                Vector3 deltaPos = temp_rb.transform.position - transform.position;
                Vector3 force = deltaPos.normalized * 100.0f;
                temp_rb.AddForce(force * explosionForce); 


            }
        }

        Destroy(gameObject, m_source.clip.length);
        Destroy(GetComponent<SpriteRenderer>());
        Destroy(GetComponent<BoxCollider>()); 
    }

    IEnumerator ShatterRocket()
    {
        m_explodeParticles.Play();
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }

    void IgnorePlayerPhysics()
    {
        m_player = GameObject.FindWithTag("Player");
        Physics.IgnoreCollision(GetComponent<BoxCollider>(), m_player.transform.GetChild(0).GetComponent<BoxCollider>());
    }
}
