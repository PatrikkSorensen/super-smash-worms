using UnityEngine;
using System.Collections;

public class ExplodeBomb : MonoBehaviour {

    bool running = false; 

    public void Explode()
    {
        if(!running)
        StartCoroutine(StartExplode()); 
    }

    IEnumerator StartExplode()
    {
        running = true; 
        Debug.Log("Exploding..."); 
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject); 
    }
}
