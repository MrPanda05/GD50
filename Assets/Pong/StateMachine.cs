using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StateMachine : MonoBehaviour
{
    public static StateMachine Instance;

    public GameStats GameStats;

    public static event Action OnGameStateEnter, OnGameRestart;

    public bool Serve, Game, Win, AIplay, HPlay;

    public int Winner = 0;//One for player one and two for player two

    public GameObject ServeState, AI;
    public TextMeshProUGUI ServeText;

    string ai = "AI";
    private void Awake()
    {
        if(Instance == null && Instance != this)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        RestartGame();
    }

    private void OnEnable()
    {
        ScoreText.OnWin += EnterWinningState;
    }
    private void OnDisable()
    {
        ScoreText.OnWin -= EnterWinningState;
    }
    private void Update()
    {
        //Enters human vs human mode
        if (Input.GetKeyDown(KeyCode.Return) && !Game && !Win)
        {
            if (AIplay) return;
            EnterGameState();
            AIplay = false;
            HPlay = true;
            AI.GetComponent<PaddleMovement>().enabled = true;
            AI.GetComponent<PaddleAI>().enabled = false;
        }
        //Enter Human vs AI
        if (Input.GetKeyDown(KeyCode.I) && !Game && !Win)
        {
            if (HPlay) return;
            EnterGameState();
            HPlay = false;
            AIplay = true;
            AI.GetComponent<PaddleMovement>().enabled = false;
            AI.GetComponent<PaddleAI>().enabled = true;
        }
        //Restart everything
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }
    public void EnterServerState()//Serving state
    {
        Serve = true;
        Win = false;
        Game = false;
        ServeState.SetActive(true);
    }
    public void EnterGameState()//Game state
    {
        Game = true;
        Serve = false;
        Win = false;
        ServeState.SetActive(false);
        OnGameStateEnter?.Invoke();
    }

    public void EnterWinningState(int winner)//Winner state
    {
        Win = true;
        Game = false;
        Serve = false;
        ServeState.SetActive(true);
        ServeText.text = $"Player {(winner == 1 ? winner : ai)} wins\n press R to restart";
    }
    public void ChangeTxt(int player)
    {
        if (AIplay)
        {
            ServeText.text = $"Player {(player == 1 ? player : ai)} turn\nPress I";
        }
        else
        {
            ServeText.text = $"Player {player} turn\nPress Enter";
        }
    }
    public void RestartGame()
    {
        Winner = 0;
        Game = false;
        Serve = false;
        Win = false;
        AIplay = false;
        HPlay = false;
        ServeText.text = "Press Enter to start\n Press I to play with an AI";
        ResetScores();
        EnterServerState();
        OnGameRestart?.Invoke();

    }
    public void ResetScores()
    {
        GameStats.P1Score = 0;
        GameStats.P2Score = 0;
    }
}
