using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class StepTowardsPlayer : Action {
    public SharedGameObject player; 
    public SharedGameObject self;

    public Rigidbody rb;


    public override void OnStart()
    {
        rb = gameObject.GetComponent<Rigidbody>(); 
    }

    public override TaskStatus OnUpdate()
    {
        rb.AddForce(Vector3.right);    
        return TaskStatus.Success;
    }
}
