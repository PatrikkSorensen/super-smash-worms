using UnityEngine;
using System.Collections;

public class bulletBehaviour : MonoBehaviour {

    public int bulletDamage = 10; 

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            coll.gameObject.SendMessage("ApplyDamage", bulletDamage);
            Destroy(gameObject); 
        }
    }
}
