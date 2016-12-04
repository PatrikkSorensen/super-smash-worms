using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class FireGun : Action {

    public float fireRate = 0;
    public SharedGameObject target;
    public GameObject projectile;
    public float reloadTime = 2.0f;
    public AudioClip gunSound; 


    private GameObject weaponEdge;
    private AudioSource m_source; 
    private float m_timeSinceFired = 0.0f;

    public override void OnStart()
    {
        m_source = transform.GetComponent<AudioSource>();
        m_source.clip = gunSound; 
        weaponEdge = transform.GetChild(0).GetChild(1).gameObject; 
    }

    public override TaskStatus OnUpdate()
    {
        Vector3 _direction = (target.Value.transform.position - transform.position).normalized;
        Quaternion _lookRotation = Quaternion.LookRotation(_direction);
        weaponEdge.transform.rotation = _lookRotation; 

        if (Time.time > reloadTime + m_timeSinceFired)
        {
            CreateBulletProjectile();
            m_timeSinceFired = Time.time;
            return TaskStatus.Success;
        }
        else
            return TaskStatus.Running;
    }

    void CreateBulletProjectile()
    {
        //find the vector pointing from our position to the target
        Vector3 _direction = (target.Value.transform.position - transform.position).normalized;
        Quaternion _lookRotation = Quaternion.LookRotation(_direction);
        _lookRotation = _lookRotation * Quaternion.AngleAxis(-90, Vector3.up); // NOTE: Has to like this because of some unknown reason

        GameObject bullet = Object.Instantiate(projectile, weaponEdge.transform.position, _lookRotation) as GameObject;

        m_source.Play(); 


    }
}
