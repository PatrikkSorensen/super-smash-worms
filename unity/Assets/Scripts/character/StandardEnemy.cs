using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI; 
public class StandardEnemy : MonoBehaviour {

    public Transform[] bodyparts; 

    [System.Serializable]
    public class EnemyStats
    {
        public int health = 100; 
    }

    public EnemyStats stats = new EnemyStats();

    private MeshRenderer m_renderer;
    private Material m_enemyMat;
    private Color m_orgColor;
    private Color m_dmgColor;
    private Animator m_anim;

    private Text t; 

    void Awake()
    {
        m_renderer = GetComponentInChildren<MeshRenderer>();
        m_enemyMat = m_renderer.material;
        m_orgColor = m_enemyMat.color;
        m_dmgColor = Color.red;
        m_anim = GetComponent<Animator>();

        t = GetComponentInChildren<Text>(); 
    }

    void Update()
    {
        t.text = "Health: " + stats.health.ToString(); 
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Projectile>())
        {
            Projectile p = other.gameObject.GetComponent<Projectile>();
            ApplyDamage(p.damage); 
        } 
    }

    public void ApplyDamage(int damage)
    {
        StartCoroutine(FireMaterialChange()); 

        stats.health -= damage;
        //m_anim.SetInteger("health", stats.health);

        if (stats.health <= 0)
            KillEnemy(); 
    }

    IEnumerator FireMaterialChange()
    {
        m_enemyMat.DOColor(m_dmgColor, 0.2f);
        yield return new WaitForSeconds(0.2f);
        m_enemyMat.DOColor(m_orgColor, 0.2f); 
    }

    public void KillEnemy()
    {

        Destroy(m_anim); 
        GameMaster.KillEnemy(gameObject, 2.0f);

        foreach (Transform t in bodyparts)
            t.parent = null;

        foreach (Transform t in bodyparts)
            AddRandomForce(t, -800.0f, 800.0f);
    }

    public void AddRandomForce(Transform t, float min, float max)
    {
        Rigidbody2D rb = t.GetComponent<Rigidbody2D>();

        if (!t.GetComponent<Rigidbody2D>())
            rb = t.gameObject.AddComponent<Rigidbody2D>();

        rb.isKinematic = false;
        rb.AddForce(new Vector2(Random.Range(min, max), Random.Range(min, max)));
    }
}
