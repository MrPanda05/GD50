using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dali : MonoBehaviour
{
    private Rigidbody2D rig;

    private AudioSource source;

    [SerializeField]
    private float forceJ;

    private event Action OnJump;



    private void OnEnable()
    {
        OnJump += Jump;
        PlayerKill.OnRestart += ResetPos;
    }
    private void OnDisable()
    {
        OnJump -= Jump;
        PlayerKill.OnRestart -= ResetPos;
    }

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!BirdStateMachine.Instance.PlayState || BirdStateMachine.Instance.LoseState || BirdStateMachine.Instance.PauseState)
        {
            rig.velocity = Vector2.zero;
            rig.gravityScale = 0;
            return;
        }
        else
        {
            rig.gravityScale = 2.5f;
        }

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            OnJump?.Invoke();
        }
    }
    private void Jump()
    {
        source.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
        source.Play();
        rig.velocity = Vector2.zero;
        rig.velocity = forceJ * Vector2.up;
    }

    private void ResetPos()
    {
        transform.position = new Vector3(-2.9f, 0, 0);
    }
}
