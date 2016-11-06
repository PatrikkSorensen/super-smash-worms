using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class IsFacingObject : Conditional {

    public SharedGameObject targetObject;

    public override TaskStatus OnUpdate()
    {
        float dot = Vector3.Dot(transform.forward, (targetObject.Value.transform.position - transform.position).normalized);
        if (dot > 0.7f) {
            return TaskStatus.Failure;
        } else {
            return TaskStatus.Success;
        }
    }
}
