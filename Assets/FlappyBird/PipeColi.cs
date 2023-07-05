using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeColi : MonoBehaviour
{
    public static event Action OnPipeHit;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit");
            BirdStateMachine.Instance.PlayState = false;
            BirdStateMachine.Instance.LoseState = true;
            OnPipeHit?.Invoke();
        }
    }
}
