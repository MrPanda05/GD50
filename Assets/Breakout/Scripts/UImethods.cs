using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImethods : MonoBehaviour
{
    [SerializeField]
    private GameObject StartUI, SelectPaddleUI, HighScoreUI, InGameUI, LoseUI, WinUI, ServeStateUI, GamePlayUI;

    public void OnStartUI()//START GAME
    {
        StartUI.SetActive(true);
        SelectPaddleUI.SetActive(false);
        HighScoreUI.SetActive(false);
        InGameUI.SetActive(false);
        LoseUI.SetActive(false);
        WinUI.SetActive(false);
    }

    public void OnSelectedPaddleUI()//SELECT PADDLE
    {
        StartUI.SetActive(false);
        SelectPaddleUI.SetActive(true);
        HighScoreUI.SetActive(false);
        InGameUI.SetActive(false);
        LoseUI.SetActive(false);
        WinUI.SetActive(false);
    }
    public void OnHighScoreUI()
    {
        StartUI.SetActive(false);
        SelectPaddleUI.SetActive(false);
        HighScoreUI.SetActive(true);
        InGameUI.SetActive(false);
        LoseUI.SetActive(false);
        WinUI.SetActive(false);
    }
    public void OnInGameUI()//WHEN GAMEPLAY STARTS
    {
        StartUI.SetActive(false);
        SelectPaddleUI.SetActive(false);
        HighScoreUI.SetActive(false);
        InGameUI.SetActive(true);
        LoseUI.SetActive(false);
        WinUI.SetActive(false);
        ServeStateUI.SetActive(false);
        GamePlayUI.SetActive(true);
    }

    public void OnGameOver()
    {
        StartUI.SetActive(false);
        SelectPaddleUI.SetActive(false);
        HighScoreUI.SetActive(false);
        InGameUI.SetActive(false);
        LoseUI.SetActive(true);
        WinUI.SetActive(false);
    }
    public void OnVictory()
    {
        StartUI.SetActive(false);
        SelectPaddleUI.SetActive(false);
        HighScoreUI.SetActive(false);
        InGameUI.SetActive(false);
        LoseUI.SetActive(false);
        WinUI.SetActive(true);
    }
    public void OnServerState()
    {
        StartUI.SetActive(false);
        SelectPaddleUI.SetActive(false);
        HighScoreUI.SetActive(false);
        InGameUI.SetActive(true);
        LoseUI.SetActive(false);
        WinUI.SetActive(false);
        ServeStateUI.SetActive(true);
    }

}
