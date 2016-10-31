using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class CreateMoveToPoint : Conditional {

    private SharedTransformList patrolPoints;
    private BehaviorTree behaviorTree;

    private int m_currentIndex;
    private Vector3 m_currentPoint;

    public override void OnAwake()
    {
        behaviorTree = gameObject.GetComponent<BehaviorTree>();
        patrolPoints = (SharedTransformList)behaviorTree.GetVariable("PatrolPoints");
        m_currentIndex = 0;
        m_currentPoint = patrolPoints.Value[0].position;
    }

    public override TaskStatus OnUpdate()
    {

        var CurrentPoint = (SharedVector3)behaviorTree.GetVariable("PatrolPoint");
        CurrentPoint.Value = patrolPoints.Value[m_currentIndex].position;

        Debug.Log("CurrentIndex: " + m_currentIndex); 
        
        m_currentIndex++; 
        return TaskStatus.Success;
    }

}
