using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServeState : State
{
    public ServeState(ChangeState changeState) : base(changeState)
    {
    }

    public override IEnumerator Start()
    {
        ChangeState.Interface.OnServerState();
        yield return null;
    }

}
