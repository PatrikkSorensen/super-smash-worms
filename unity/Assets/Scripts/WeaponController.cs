using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

    public Transform weaponEdge; 
    public LayerMask whatToHit;
    public GameObject bulletTrailBrefab; 
         

    private SpriteRenderer m_SpriteRenderer;
    private Animator m_Anim; 
    private AudioSource m_AudioSource; 
    private float m_Timer = 1.0f;
    private float m_Delay = -1.0f;  

	void Start () {
        m_AudioSource = GetComponentInChildren<AudioSource>();
        m_Anim = GetComponent<Animator>(); 
    }

    public void Shoot()
    {
        Vector2 screenMousePos = Input.mousePosition;
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(screenMousePos).x, Camera.main.ScreenToWorldPoint(screenMousePos).y);
        Vector2 weaponEdgePos = new Vector2(weaponEdge.position.x, weaponEdge.position.y);

        RaycastHit2D hit = Physics2D.Raycast(weaponEdge.position, mousePosition - weaponEdgePos, 1000.0f, whatToHit);
        CreateBulletTrail(); 
        if (hit.collider != null)
        {
            Debug.DrawLine(weaponEdgePos, hit.point, Color.red);
            Debug.Log("We hit" + hit.collider.name);
            m_AudioSource.Play();
        }

        m_Anim.SetTrigger("Shoot"); 
        //Debug.DrawLine(weaponEdgePos, mousePosition, Color.blue);
    }

    void CreateBulletTrail()
    {
        Instantiate(bulletTrailBrefab, weaponEdge.transform.position, weaponEdge.rotation); 
    }
}
