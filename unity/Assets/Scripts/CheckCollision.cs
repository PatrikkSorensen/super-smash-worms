using UnityEngine;
using System.Collections;

public class CheckCollision : MonoBehaviour {

    [HideInInspector]
    public bool isStuck = false;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("Obstacle")) {
            Debug.Log("Hitted an obstacle!");
            isStuck = true; 
        }

    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            Debug.Log("Moved away from an obstacle!");
            isStuck = false;
        }

    }

}
