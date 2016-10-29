using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class FlipTowardsPlayer : Action {
    public SharedGameObject player; 

    public override void OnStart()
    {
        
    }

    public override TaskStatus OnUpdate()
    {
        //transform.GetChild(0).transform.rotation = transform.GetChild(0).transform.rotation * Quaternion.Euler(0, 180, 0);
        transform.rotation = transform.rotation * Quaternion.Euler(0, 180, 0);
        return TaskStatus.Success; 
    }
}
