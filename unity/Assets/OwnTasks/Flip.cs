using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using DG.Tweening; 

public class FlipTowardsPlayer : Action {

    public override TaskStatus OnUpdate()
    {
        Vector3 vector = transform.rotation.eulerAngles;
        Vector3 vector2 = Quaternion.AngleAxis(-45, Vector3.up) * vector;
        transform.DORotateQuaternion(transform.rotation * Quaternion.Euler(0, 180, 0), 1.0f);
        return TaskStatus.Success; 
    }
}
