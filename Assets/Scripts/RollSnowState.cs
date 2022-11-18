using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollSnowState : AIState
{
    [SerializeField] LayerMask layer;
    [SerializeField] LayerMask layer2;
    RollSnow rollSnow;
    [SerializeField] int minCollectedSnow, maxCollectedSnow;
    [SerializeField] int requiredSnow;
    AI ai;
    [SerializeField] int distance;
    RaycastHit hit;
    Ground ground;
    Vector3 currDestination;
    
    public override void StartState(Animations action)
    {
        ai = GetComponentInParent<AI>();
        rollSnow = GetComponentInParent<RollSnow>();
        ai.animations.RollSnowAnim();
        requiredSnow = Random.Range(minCollectedSnow, maxCollectedSnow);
        currDestination = FindWaypoint().position;
        ai.agent.SetDestination(currDestination);
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawSphere(transform.position, distance);
    //}
    public override void UpdateState(Animations action)
    {
        Debug.DrawRay(transform.position + Vector3.up, -transform.up, Color.red);
        if (rollSnow.collectedSnow >= requiredSnow)
        {
            ai.makeBridgeState.bridge = ground.bridges[ai.aiIndex];
            ai.currState = ai.makeBridgeState;
            return;
        }
        else if (Vector3.Distance(currDestination, transform.position) < 2f)
        {
            currDestination = FindWaypoint().position;
            ai.agent.SetDestination(currDestination);
        }
    }
    public Transform FindWaypoint()
    {
        Physics.Raycast(transform.position + Vector3.up, -transform.up, out hit, 100, layer);

        
        if (hit.collider.TryGetComponent(out Ground _ground) && hit.collider != null)
        {
            this.ground = _ground;
        }
        //Collider[] colliders = Physics.OverlapSphere(this.transform.position, distance, layer2);
        return ground.wayPoints[Random.Range(0, ground.wayPoints.Count- 1)].transform;  
    }
}
