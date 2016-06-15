using UnityEngine;
using System.Collections;

public class RocketBehaviour : MonoBehaviour {

    public float timeBeforeDestroyed = 1;
    public float speed = 10.0f; 
    void Start() {
        AddForce(); 
        Debug.Log("Firing up"); 
    }

    void Update()
    {

        Destroy(gameObject, timeBeforeDestroyed);
    }

    void AddForce()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * speed);
    }
}
