using UnityEngine;
using System.Collections; 

public class CheckCollision : MonoBehaviour {

    [HideInInspector]
    public bool isStuck = false;

    private float m_timeSinceChecked; 

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("Obstacle")) {
            Debug.Log("Hitted an obstacle!");
            if (Time.time - m_timeSinceChecked > 2.0f)
            {
                m_timeSinceChecked = Time.time;
                isStuck = true;
            }

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
