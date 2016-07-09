using UnityEngine;
using System.Collections;
using DG.Tweening; 

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

        GetComponentInChildren<SpriteRenderer>().material.DOColor(Color.black, 2.0f); // Body and model is child 
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject); 
    }
}
