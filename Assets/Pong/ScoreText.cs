using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI p1ScoreTxt, p2ScoreTxt;

    public static event Action<int> OnWin;

    private void OnEnable()
    {
        Ball.OnScoreHit += ChangeTextScore;
        StateMachine.OnGameRestart += ResetTextScore;
    }
    private void OnDisable()
    {
        Ball.OnScoreHit -= ChangeTextScore;
        StateMachine.OnGameRestart -= ResetTextScore;
    }
    //Updates scores
    public void ChangeTextScore(int player)
    {
        Debug.Log(player);
        if (player == 1)
        {
            StateMachine.Instance.GameStats.P1Score++;
            p1ScoreTxt.text = StateMachine.Instance.GameStats.P1Score.ToString();
            if(StateMachine.Instance.GameStats.P1Score == StateMachine.Instance.GameStats.WinScore)
            {
                OnWin?.Invoke(1);
            }
        }
        else
        {
            StateMachine.Instance.GameStats.P2Score++;
            p2ScoreTxt.text = StateMachine.Instance.GameStats.P2Score.ToString();
            if (StateMachine.Instance.GameStats.P2Score == StateMachine.Instance.GameStats.WinScore)
            {
                OnWin?.Invoke(2);
            }
        }
    }
    public void ResetTextScore()
    {
        p1ScoreTxt.text = "0";
        p2ScoreTxt.text = "0";
    }
}
