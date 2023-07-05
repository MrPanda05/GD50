using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : State
{
    public StartState(ChangeState changeState) : base(changeState)
    {
    }

    public override IEnumerator Start()
    {
        Debug.Log("Penis");
        yield return null;
    }
}
