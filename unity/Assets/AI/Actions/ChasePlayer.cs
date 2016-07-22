using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using RAIN.Serialization;
using RAIN.Representation;
using System.Threading; 

[RAINAction]
public class ChasePlayer : RAINAction
{

    public float maxDistance = 20.0f; 
    private Rigidbody2D m_rb;
    private GameObject m_target;
    private float m_chaseSpeed; 

    public override void Start(RAIN.Core.AI ai)
    {
        //Debug.Log("Running chase Action"); 
        m_target = ai.WorkingMemory.GetItem<GameObject>("player");
        m_chaseSpeed = ai.WorkingMemory.GetItem<float>("chaseSpeed");
        m_rb = ai.Body.GetComponent<Rigidbody2D>();

        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        float distance = Vector3.Distance(m_target.transform.position, ai.Body.transform.position);
        Vector3 direction = (m_target.transform.position - ai.Body.transform.position).normalized;
        direction *= m_chaseSpeed * Time.fixedDeltaTime;

        m_rb.AddForce(direction, ForceMode2D.Force);

        if (distance > maxDistance)
        {
            return ActionResult.FAILURE;
        }
        else if (distance < 2.0f)
            return ActionResult.SUCCESS;

        return ActionResult.RUNNING;

    }

    public void UpdatePath()
    {
        Debug.Log("Updating path from action..."); 
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}