using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class Explode : RAINAction
{

    private ExplodeBomb explodeScript; 

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
        explodeScript = ai.Body.GetComponent<ExplodeBomb>();
        explodeScript.Explode(); 
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}