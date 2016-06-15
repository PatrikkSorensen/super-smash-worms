using UnityEngine;
using System.Collections;

public class RLauncherBehaviour : Weapon {

    public Transform weaponEdge;
    public LayerMask whatToHit;
    public GameObject rocketProjectile;
    public float speed = 300.0f; 

    private GameObject m_rocket; 

    override
    public void Shoot() {
        base.Shoot();

        CreateRocketTrail();

    }

    void CreateRocketTrail()
    {
        Instantiate(rocketProjectile, weaponEdge.transform.position, weaponEdge.rotation);
    }
}
