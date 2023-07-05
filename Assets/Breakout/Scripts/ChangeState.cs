using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeState : SMBreakout
{

    [SerializeField]
    private UImethods ui;

    [SerializeField]
    private GameObject player, spawner;

    public UImethods Interface => ui;
    public GameObject Player => player;
    private void Start()
    {
        SetState(new StartState(this));
    }
    public void OnStartButton()
    {
        SetState(new PaddleSelect(this));
    }

    public void OnHighScoreButton()
    {
        SetState(new HighScoreState(this));
    }

    public void OnGamePlayerStartButtonTest()
    {
        SetState(new PlayState(this, player, spawner));
    }
}
