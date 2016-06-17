using UnityEngine;
using System.Collections;

public class RocketProjectile : MonoBehaviour {

    /* The rocket should
     * Have exploding particles 
     * Shake the screen
     * Apply damage
     * // Should be moved to weapon 
     * Have a cooldown timer 
     * Have smoke from gun 
     * Signify slider for holding down 
     * Trigger animation on fire
     */

    public float timeBeforeDestroyed = 1;
    public float speed = 10.0f;
    public int rocketDamage = 30;
    public float m_radius = 5.0f;
    public float explosionForce;
    public LayerMask thingsToExplode; 

    public GameObject body, player; 

    private AudioSource m_source; 

    void Start() {
        AddForce();
        Destroy(gameObject, timeBeforeDestroyed);
        Debug.Log("Firing up");
        m_source = GetComponent<AudioSource>();

        player = GameObject.FindWithTag("Player");
        body = player.transform.GetChild(1).gameObject;

        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), body.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player.GetComponent<Collider2D>());

    }

    void AddForce()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * speed);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red; 
        Gizmos.DrawWireSphere(transform.position, m_radius);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        m_source.Play();

        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, m_radius, thingsToExplode);

        foreach (Collider2D m_obj in objects) {
            Rigidbody2D temp_rb = m_obj.GetComponent<Rigidbody2D>();

            if (m_obj.gameObject.tag == "Enemy")
            {
                Debug.Log("Applying damage"); 
                StartCoroutine(ShatterRocket());
                m_obj.gameObject.SendMessage("ApplyDamage", rocketDamage);

            }

            if (temp_rb != null) {

                Vector3 deltaPos = temp_rb.transform.position - transform.position;
                Vector3 force = deltaPos.normalized * 100.0f;
                temp_rb.AddForce(force * explosionForce); 


            }
        }

        Destroy(gameObject, m_source.clip.length);
        Destroy(GetComponent<SpriteRenderer>());
        Destroy(GetComponent<BoxCollider2D>()); 
    }

    IEnumerator ShatterRocket()
    {
        //m_shatterParticles.Play();

        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }




}
