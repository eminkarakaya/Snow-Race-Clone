using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBridgeState : AIState
{
    [SerializeField] bool backStartPos;
    [SerializeField] bool isFinishing;
    [SerializeField] RollSnow rollSnow;
    public Bridge bridge;
    AI ai;
    public override void StartState(Animations action)
    {
        rollSnow = GetComponentInParent<RollSnow>();
        ai = GetComponentInParent<AI>();
        ai.agent.SetDestination(bridge.finishPos.position);
    }
    public override void UpdateState(Animations action)
    {
        if(backStartPos)
        {
            ai.agent.SetDestination(bridge.startPos.position);
            if (Vector3.Distance(transform.position, bridge.startPos.position) < .2f)
            {
                ai.currState = ai.rollSnowState;
                backStartPos = false;
            }
        }
        else
        {
            ai.agent.SetDestination(bridge.finishPos.position);
        
            if(rollSnow.collectedSnow <= 0 && !isFinishing)
            {
                backStartPos = true;
            }
            if (bridge.isFinish)
            {
                isFinishing = true;
            }
            if(isFinishing)
            {
                ai.agent.SetDestination(bridge.acrossBridge.position);
                if(Vector3.Distance(bridge.acrossBridge.position,transform.position) < .2f)
                {
                    isFinishing = false;
                    ai.currState = ai.rollSnowState;
                }
            }
        }
    }
}
