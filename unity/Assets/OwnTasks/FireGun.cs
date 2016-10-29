﻿using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class FireGun : Action {

    public float fireRate = 0;
    public SharedGameObject target;
    public GameObject projectile;
    //public GameObject weaponEdge;
    public float reloadTime = 2.0f;

    private GameObject weapon; 

    private float m_timeSinceFired = 0.0f;


    public override TaskStatus OnUpdate()
    {
        if (Time.time > reloadTime + m_timeSinceFired)
        {
            CreateBulletProjectile();
            m_timeSinceFired = Time.time;
            return TaskStatus.Success;
        }
        else
        {
            //Debug.Log("Cant fire yet!");
            return TaskStatus.Running;
        }
    }

    void CreateBulletProjectile()
    {
        //find the vector pointing from our position to the target
        Vector3 _direction = (target.Value.transform.position - transform.position).normalized;
        Quaternion _lookRotation = Quaternion.LookRotation(_direction);
        
        GameObject gb = Object.Instantiate(projectile, transform.position, transform.rotation) as GameObject;
        gb.transform.rotation = _lookRotation * Quaternion.AngleAxis(-90, Vector3.up);  // NOTE: Has to like this because of some unknown reason


        //Debug.Log("Direction: " + _direction);
        //Debug.Log("LookRotation: " + _lookRotation);
        //Debug.Log("Rotation: " + transform.rotation); 
    }
}