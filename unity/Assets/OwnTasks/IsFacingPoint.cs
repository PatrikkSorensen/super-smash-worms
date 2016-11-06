using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class IsFacingPoint : Conditional {

    public SharedVector3 point;

    public override TaskStatus OnUpdate()
    {
        float dot = Vector3.Dot(transform.forward, (point.Value - transform.position).normalized);
        if (dot > 0.7f) {
            return TaskStatus.Success;
        } else {
            return TaskStatus.Failure;
        }
    }
}
