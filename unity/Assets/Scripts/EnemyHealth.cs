using UnityEngine;
using System.Collections;
using DG.Tweening; 

public class EnemyHealth : MonoBehaviour {



    [System.Serializable]
    public class EnemyStats
    {
        public int health = 100; 
    }

    public EnemyStats stats = new EnemyStats();

    private SpriteRenderer m_renderer;
    private Material m_enemyMat;
    private Color m_orgColor;
    private Color m_dmgColor; 

    void Awake()
    {
        m_renderer = GetComponentInChildren<SpriteRenderer>();
        m_enemyMat = m_renderer.material;
        m_orgColor = m_enemyMat.color;
        m_dmgColor = Color.red; 
    }

    public void ApplyDamage(int damage)
    {

        StartCoroutine(FireMaterialChange()); 


        stats.health -= damage;
        if (stats.health <= 0)
            GameMaster.KillEnemy(gameObject); 
    }

    IEnumerator FireMaterialChange()
    {
        m_enemyMat.DOColor(m_dmgColor, 0.2f);
        yield return new WaitForSeconds(0.2f);
        m_enemyMat.DOColor(m_orgColor, 0.2f); 
    }
}
