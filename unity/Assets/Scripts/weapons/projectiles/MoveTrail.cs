using UnityEngine;
using System.Collections;
using DG.Tweening; 

public class MoveTrail : MonoBehaviour
{

    public int moveSpeed = 230;
    public int timeBeforeDestroyed = 1;
    public Color startColor, endColor;

    private LineRenderer m_lr; 

    void Start()
    {
        m_lr = GetComponent<LineRenderer>(); 
        m_lr.SetColors(startColor, endColor); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        Destroy(gameObject, timeBeforeDestroyed);
    }

    public void FadeOutTrail(float seconds)
    {
        
        Color2 c1, c2;
        c1.ca = startColor;
        c1.cb = endColor;

        c2.ca = new Color(0.0f, 0.0f, 0.0f, 0.0f); 
        c2.cb = new Color(0.0f, 0.0f, 0.0f, 0.0f);

        m_lr.DOColor(c1, c2, seconds); 
        Destroy(gameObject, seconds); 
    }
}
