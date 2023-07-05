using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleSelect : State
{
    public PaddleSelect(ChangeState changeState) : base(changeState)
    {
    }

    public override IEnumerator Start()
    {
        ChangeState.Interface.OnSelectedPaddleUI();
        Debug.Log("Long");
        yield return null;
    }
}
