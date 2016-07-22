using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class MoveForward : RAINAction
{

    private Rigidbody2D m_rb;
    private int m_direction;
    private float m_speed;
    private CheckCollision m_collScript; 

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
        m_rb = ai.Body.GetComponent<Rigidbody2D>();
        m_collScript = ai.Body.GetComponent<CheckCollision>(); 
        m_direction = ai.WorkingMemory.GetItem<int>("direction");
        m_speed = ai.WorkingMemory.GetItem<float>("speed");  
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {

        m_rb.velocity = new Vector3(m_speed * m_direction, 0.0f, 0.0f);
        if (m_collScript.isStuck == true)
        {
            Debug.Log("I should change direction");
            ai.WorkingMemory.SetItem<int>("direction", m_direction * -1); 
        } 
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}