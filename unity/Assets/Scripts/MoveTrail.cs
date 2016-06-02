using UnityEngine;
using System.Collections;

public class MoveTrail : MonoBehaviour
{

    public int moveSpeed = 230;
    public int timeBeforeDestroyed = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        Destroy(gameObject, timeBeforeDestroyed);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            coll.gameObject.SendMessage("ApplyDamage", 10);
            Debug.Log("Adding damage");
            Destroy(coll.gameObject); 
        }
        

    }
}
