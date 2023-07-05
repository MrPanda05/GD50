using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeTrigg : MonoBehaviour
{
    public static event Action OnPipePass;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Pass");
            OnPipePass?.Invoke();
        }
    }
}
