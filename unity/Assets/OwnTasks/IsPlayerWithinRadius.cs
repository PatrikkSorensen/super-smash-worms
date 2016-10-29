using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class IsPlayerWithinRadius : Conditional {

    public SharedFloat detectionRadius; 

    public override void OnStart()
    {
        

    }

    public override TaskStatus OnUpdate()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius.Value);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].name == "PlayerBody")
                return TaskStatus.Success; 
            i++;
        }

        return TaskStatus.Failure; 
    }
}
