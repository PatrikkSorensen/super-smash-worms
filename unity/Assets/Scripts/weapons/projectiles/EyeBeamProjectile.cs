using UnityEngine;
using System.Collections;
using DG.Tweening; 

public class EyeBeamProjectile : MonoBehaviour {


    private LineRenderer m_lr;
    private Transform[] transforms;
    private float m_startWidth, m_endWidth, m_narrowSpeed; 

    void Update()
    {
        if (m_lr) UpdateBeam();
    }

    public void Instantiate(Transform t1, Transform t2, float startWidth, float endWidth, float narrowSpeed)
    {
        m_lr = GetComponent<LineRenderer>();
        m_lr.SetWidth(startWidth, endWidth);

        m_startWidth = startWidth;
        m_endWidth = endWidth;
        m_narrowSpeed = narrowSpeed; 

        transforms = new Transform[2];
        transforms[0] = t1;
        transforms[1] = t2;

        StartCoroutine(NarrowBeam());
    }

    void UpdateBeam ()
    {
        m_lr.SetPosition(0, transforms[0].position);
        m_lr.SetPosition(1, transforms[1].position);
    }

    public IEnumerator NarrowBeam ()
    {
        while (m_endWidth > m_startWidth)
        {
            DOTween.To(() => m_endWidth, x => m_endWidth = x, 0.0f, 2); // TODO, evaluate this and setEase
            m_lr.SetWidth(m_startWidth, m_endWidth); 
            yield return new WaitForSeconds(m_narrowSpeed);
        }

        Destroy(gameObject);
    }
}
