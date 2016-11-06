using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class FlipTowardsPlayer : Action {

    public override TaskStatus OnUpdate()
    {
        transform.rotation = transform.rotation * Quaternion.Euler(0, 180, 0);
        return TaskStatus.Success; 
    }
}
