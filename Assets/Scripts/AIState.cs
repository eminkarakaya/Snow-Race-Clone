using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIState : MonoBehaviour
{
    public abstract void StartState(Animations action);
    public abstract void UpdateState(Animations action);
}
