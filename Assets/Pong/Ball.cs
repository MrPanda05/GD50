using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float ballDx, ballDy;

    private Rigidbody2D rig;

    public static event Action<int> OnScoreHit;

    public AudioClip[] Audios;

    private AudioSource source;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
    }
    private void Start()
    {
        StateMachine.Instance.GameStats.BallSpeed = 1250f;//Resets ball speeds after a new game
    }
    private void OnEnable()
    {
        StateMachine.OnGameStateEnter += StartVelocity;
        StateMachine.OnGameRestart += Reset;
    }
    private void OnDisable()
    {
        StateMachine.OnGameStateEnter -= StartVelocity;
        StateMachine.OnGameStateEnter -= Reset;

    }

    //Sets ball starting position and velocity
    private void StartVelocity()
    {
        if (StateMachine.Instance.Serve || StateMachine.Instance.Win)
        {
            return;
        }
        gameObject.transform.position = Vector2.zero;
        ballDy = UnityEngine.Random.Range(-375, 376);
        if(StateMachine.Instance.Winner == 0)
        {
            ballDx = (UnityEngine.Random.Range(0, 2) == 0) ? -750 : 750;
        }
        else
        {
            ballDx = StateMachine.Instance.Winner == 1 ? -750 : 750;
        }
        rig.velocity = Time.deltaTime * StateMachine.Instance.GameStats.BallSpeed * new Vector2(ballDx, ballDy).normalized;
        Debug.Log($"{ballDx} {ballDy}");
    }

    //Resets velocity and position to 0
    public void Reset()
    {
        rig.velocity = Vector2.zero;
        gameObject.transform.position = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Colision between paddles
        if (collision.gameObject.CompareTag("Paddle"))
        {
            Debug.Log("Hit");
            StateMachine.Instance.GameStats.BallSpeed *= 1.10f;
            ballDx *= -1;
            if (ballDy < 0)
            {
                ballDy = -UnityEngine.Random.Range(100, 1000);
            }
            else
            {
                ballDy = UnityEngine.Random.Range(100, 1000);
            }
            source.PlayOneShot(Audios[0]);
            rig.velocity = Time.deltaTime * StateMachine.Instance.GameStats.BallSpeed * new Vector2(ballDx, ballDy).normalized;
        }else if (collision.gameObject.CompareTag("Block"))//Colision between the up and down borders
        {
            Debug.Log("Hit Block");
            ballDy *= -1;
            rig.velocity = Time.deltaTime * StateMachine.Instance.GameStats.BallSpeed * new Vector2(ballDx, ballDy * 1.3f).normalized;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
        //Player 2 scores
        if (collision.gameObject.CompareTag("Left"))
        {
            StateMachine.Instance.GameStats.BallSpeed = 1250;
            StateMachine.Instance.Winner = 2;
            StateMachine.Instance.ChangeTxt(1);
            OnScoreHit?.Invoke(2);
            source.PlayOneShot(Audios[1]);
            if(StateMachine.Instance.GameStats.P2Score < StateMachine.Instance.GameStats.WinScore)
            {
                StateMachine.Instance.EnterServerState();
            }
            else
            {
                StateMachine.Instance.Win = true;
            }
        }
        else if (collision.gameObject.CompareTag("Right"))//Player 1 scores
        {
            StateMachine.Instance.GameStats.BallSpeed = 1250;
            StateMachine.Instance.Winner = 1;
            StateMachine.Instance.ChangeTxt(2);
            OnScoreHit?.Invoke(1);
            source.PlayOneShot(Audios[1]);
            if (StateMachine.Instance.GameStats.P1Score < StateMachine.Instance.GameStats.WinScore)
            {
                StateMachine.Instance.EnterServerState();
            }
            else
            {
                StateMachine.Instance.Win = true;
            }
        }
    }
}
