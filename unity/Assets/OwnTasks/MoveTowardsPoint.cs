﻿using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class MoveTowardsPoint : Action {
    public SharedVector3 point; 
    public SharedGameObject self;
    public SharedFloat moveSpeed; 

    private NavMeshAgent navAgent; 

    public override void OnStart()
    {
        navAgent = gameObject.GetComponent<NavMeshAgent>(); 
    }

    public override TaskStatus OnUpdate()
    {
        navAgent.SetDestination(point.Value); 

        float distance = Vector3.Distance(point.Value, transform.position);
        if (distance > 1.5f)
        {
            //Debug.Log("Returning running, distance: " + distance);
            return TaskStatus.Running;
        }
        else
        {
            //Debug.Log("Returning sucess, distance: " + distance); 
                    Debug.Log("At point!"); 
            return TaskStatus.Success;
        }


    }
}
