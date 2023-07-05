using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SMBreakout : MonoBehaviour 
{
    protected State State;

    public void SetState(State state)
    {
        State = state;
        StartCoroutine(State.Start());
    }
}
