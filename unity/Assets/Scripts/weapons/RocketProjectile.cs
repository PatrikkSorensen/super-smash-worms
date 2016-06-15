using UnityEngine;
using System.Collections;

public class RocketProjectile : MonoBehaviour {

    public float timeBeforeDestroyed = 1;
    public float speed = 10.0f;

    public GameObject body, player; 

    private AudioSource m_source; 

    void Start() {
        AddForce();
        Destroy(gameObject, timeBeforeDestroyed);
        Debug.Log("Firing up");
        m_source = GetComponent<AudioSource>();

        player = GameObject.FindWithTag("Player");
        body = player.transform.GetChild(1).gameObject;
        Debug.Log("body ? : " + body.name); 

        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), body.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player.GetComponent<Collider2D>());

    }

    void AddForce()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * speed);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log(coll.gameObject.name);
        m_source.Play();

        
        Destroy(gameObject, m_source.clip.length);
        Destroy(GetComponent<SpriteRenderer>());
        Destroy(GetComponent<BoxCollider2D>()); 
    }


}
