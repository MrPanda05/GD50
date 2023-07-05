using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : State
{
    public GameOverState(ChangeState changeState) : base(changeState)
    {
    }

    public override IEnumerator Start()
    {
        ChangeState.Interface.OnGameOver();
        yield return null;
    }
}
