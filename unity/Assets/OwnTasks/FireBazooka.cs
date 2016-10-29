using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;


public class FireBazooka : Action {
    public float fireRate = 0;
    public SharedGameObject target;
    public GameObject rocketProjectile;
    public Transform weaponEdge; 
    public float reloadTime = 2.0f;

    private float m_timeSinceFired = 0.0f; 


    public override TaskStatus OnUpdate()
    {
        if (Time.time > reloadTime + m_timeSinceFired)
        {
            CreateRocket();
            m_timeSinceFired = Time.time;
            return TaskStatus.Success;
        }
        else
        {
            Debug.Log("Cant fire yet!");
            return TaskStatus.Running;
        }
    }

    void CreateRocket()
    {
        Object.Instantiate(rocketProjectile, transform.position, transform.rotation);
    }
}
