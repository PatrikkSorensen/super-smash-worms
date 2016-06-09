using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour {
	
	void Update () {
        Vector3 mouse_position = Input.mousePosition;
        if(!Camera.main.orthographic)
            mouse_position.z = Camera.main.farClipPlane; 

        Vector3 difference = Camera.main.ScreenToWorldPoint(mouse_position) - transform.position;
        difference.Normalize();

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotZ); 
    }
}
