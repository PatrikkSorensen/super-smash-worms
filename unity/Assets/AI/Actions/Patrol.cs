using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathfinding; 
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class Patrol : RAINAction
{
    private Vector3 m_moveToPoint;
    private Vector3 m_direction; 
    private Rigidbody2D m_rb;
    private float m_patrolSpeed;
    private float m_distanceToPoint;
    private bool m_isWaiting; 
    private CheckCollision m_collisionScript;
    private float m_MinThreshold = 1.0f;
    private float m_MaxThreshold = 20.0f;

    public override void Start(RAIN.Core.AI ai)
    {

        m_isWaiting = ai.WorkingMemory.GetItem<bool>("isWaiting");

        if (m_isWaiting)
        {
            Debug.Log("I am waiting for wait animation"); 
        }
        m_distanceToPoint = Vector3.Distance(ai.Body.transform.position, m_moveToPoint);
        m_collisionScript = ai.Body.GetComponent<CheckCollision>();

        Debug.Log("Starting"); 

        if (m_distanceToPoint > m_MaxThreshold)
            AssignNewPoint(ai);
        else if (m_distanceToPoint < m_MinThreshold)
            AssignNewPoint(ai);

        m_rb = ai.Body.GetComponent<Rigidbody2D>();
        m_patrolSpeed = ai.WorkingMemory.GetItem<float>("patrolSpeed");
        m_moveToPoint = ai.WorkingMemory.GetItem<Vector3>("patrolPoint");
        
        m_direction = (m_moveToPoint - ai.Body.transform.position).normalized;

        if (m_collisionScript.isStuck)
        {
            //Debug.Log("I am stuck, so fiding a new point");
            AssignPointAwayFromCorner(ai);
            //m_direction = (m_moveToPoint - ai.Body.transform.position).normalized;
        }

        base.Start(ai);

    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        Debug.DrawLine(ai.Body.transform.position, m_moveToPoint, Color.green);

        if (m_distanceToPoint < m_MinThreshold)
        {
            Debug.Log("Returning sucess!");
            return ActionResult.SUCCESS;
        }
        else
        {
            Debug.Log("Returning running: " + m_distanceToPoint);
            m_rb.AddForce(m_direction * m_patrolSpeed, ForceMode2D.Force);
            return ActionResult.RUNNING;
        }
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }

    public void AssignNewPoint(RAIN.Core.AI ai)
    {
        Vector3 newPosition = new Vector3(ai.Body.transform.position.x + Random.Range(-7.0f, 7.0f), 0.0f, 0.0f);
        ai.WorkingMemory.SetItem<Vector3>("patrolPoint", newPosition);

        Debug.Log("Assigning new point"); 
    }

    public void AssignPointAwayFromCorner(RAIN.Core.AI ai)
    {
        m_moveToPoint.x = m_moveToPoint.x * -1;
    }
}