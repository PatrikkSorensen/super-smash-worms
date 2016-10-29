using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class IsFacingPlayer : Conditional {

    public SharedGameObject player;

    private float m_timeSinceFired = 0.0f;

    public override void OnStart()
    {
        

    }

    public override TaskStatus OnUpdate()
    {
        float dot = Vector3.Dot(transform.forward, (player.Value.transform.position - transform.position).normalized);
        if (dot > 0.7f) {
            return TaskStatus.Failure;
        } else {
            return TaskStatus.Success;
        }
    }
}
