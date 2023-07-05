using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreState : State
{
    public HighScoreState(ChangeState changeState) : base(changeState)
    {
    }

    public override IEnumerator Start()
    {
        ChangeState.Interface.OnHighScoreUI();
        Debug.Log("UI");
        yield return null;
    }
}
