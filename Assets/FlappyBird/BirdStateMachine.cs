using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdStateMachine : MonoBehaviour
{
    public static BirdStateMachine Instance;

    public bool StartState = true, PlayState, LoseState, PauseState;

    internal bool isEnter;

    public static event Action OnEnterPress;

    private void Awake()
    {
        if (Instance == null && Instance != this)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            isEnter = true;
            OnEnterPress?.Invoke();
        }
        else
        {
            isEnter = false;
        }
    }
    
}
