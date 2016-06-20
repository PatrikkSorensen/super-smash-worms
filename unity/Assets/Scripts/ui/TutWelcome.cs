using UnityEngine;
using System.Collections;

public class TutWelcome : MonoBehaviour {

    private Animator m_anim; 
	// Use this for initialization
	void Start () {
        m_anim = GetComponent<Animator>(); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            m_anim.SetTrigger("begin"); 

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            m_anim.SetTrigger("exit");

    }
}
