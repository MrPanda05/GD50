using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public static event Action OnGamePause;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !BirdStateMachine.Instance.LoseState)
        {
            if (BirdStateMachine.Instance.PlayState)
            {
                BirdStateMachine.Instance.PlayState = false;
                BirdStateMachine.Instance.PauseState = true;
                BirdStateMachine.Instance.LoseState = false;
                OnGamePause?.Invoke();
            }
            else
            {
                BirdStateMachine.Instance.PlayState = true;
                BirdStateMachine.Instance.PauseState = false;
                BirdStateMachine.Instance.LoseState = false;
                OnGamePause?.Invoke();
            }
        }
    }
}
