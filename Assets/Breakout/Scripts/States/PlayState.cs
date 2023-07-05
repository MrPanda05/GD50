using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : State
{
    GameObject player;
    GameObject spawner;
    public PlayState(ChangeState changeState, GameObject Player, GameObject Spawner) : base(changeState)
    {
        player = Player;
        spawner = Spawner;
    }

    public override IEnumerator Start()
    {
        ChangeState.Interface.OnInGameUI();
        player.SetActive(true);
        spawner.SetActive(true);
        yield return null;
    }
}
