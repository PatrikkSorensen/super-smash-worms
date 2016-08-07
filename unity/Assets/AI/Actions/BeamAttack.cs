using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class BeamAttack : RAINAction
{
    private OneEyeBeamAttack attackScript;

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
        attackScript = ai.Body.GetComponent<OneEyeBeamAttack>();
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        attackScript.FireBeam(); 
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}