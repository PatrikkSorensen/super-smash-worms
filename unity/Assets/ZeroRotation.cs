using UnityEngine;
using System.Collections;

public class ZeroRotation : MonoBehaviour {

    void LateUpdate() {
        if (transform.rotation != Quaternion.Euler(0, 0, 0))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
