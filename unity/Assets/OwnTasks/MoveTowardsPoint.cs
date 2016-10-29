using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class MoveTowardsPoint : Action {
    public SharedVector3 point; 
    public SharedGameObject self;

    private Rigidbody rb; 


    public override void OnStart()
    {
        rb = gameObject.GetComponent<Rigidbody>(); 
    }

    public override TaskStatus OnUpdate()
    {
        Vector3 direction = (point.Value - transform.position).normalized;
        rb.AddForce(direction);    
        return TaskStatus.Success;
    }
}
