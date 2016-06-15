using UnityEngine;
using System.Collections;

public class RLauncherBehaviour : Weapon {

    public Transform weaponEdge;
    public LayerMask whatToHit;
    public GameObject rocketProjectile;
    public GameObject body, player; 
    public float speed = 300.0f;

    private GameObject m_rocket;

    override
    public void Shoot() {
        base.Shoot();
        CreateRocket();

    }

    override
    public void ArmWeapon()
    {

    }

    void CreateRocket()
    {
        Instantiate(rocketProjectile, weaponEdge.transform.position, weaponEdge.rotation);
    }
}
