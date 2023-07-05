using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BirdCanvas : MonoBehaviour
{
    [SerializeField]
    private GameObject ScoreUI, PauseUI, KillUI, StartUI, CoolDownUI;

    private void Start()
    {
        ScoreUI.SetActive(false);
        StartUI.SetActive(true);
    }
    private void OnEnable()
    {
        BirdStateMachine.OnEnterPress += EnablesCoolDown;
        CoolDown.OnCoolDownEnd += EnableScore;
        CoolDown.OnCoolDownEnter += DisiableStart;
        PipeColi.OnPipeHit += KillUIEnable;
        PlayerKill.OnRestart += EnablesCoolDown;
        PauseGame.OnGamePause += PauseEnable;
    }
    private void OnDisable()
    {
        BirdStateMachine.OnEnterPress -= EnablesCoolDown;
        CoolDown.OnCoolDownEnd -= EnableScore;
        CoolDown.OnCoolDownEnter -= DisiableStart;
        PipeColi.OnPipeHit -= KillUIEnable;
        PlayerKill.OnRestart -= EnablesCoolDown;
        PauseGame.OnGamePause -= PauseEnable;
    }
    public void EnablesCoolDown()
    {
        CoolDownUI.SetActive(true);
    }
    public void DisiableStart()
    {
        StartUI.SetActive(false);
    }
    public void EnableScore()
    {
        ScoreUI.SetActive(true);
    }
    public void KillUIEnable()
    {
        KillUI.SetActive(true);
    }
    public void PauseEnable()
    {
        PauseUI.SetActive(!PauseUI.activeSelf);
    }
    
}
