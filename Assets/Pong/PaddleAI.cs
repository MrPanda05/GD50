using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleAI : MonoBehaviour
{
    private Rigidbody2D rig;

    [SerializeField]private GameObject Ball;

    [SerializeField] private float paddleSpeed;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (StateMachine.Instance.Serve || StateMachine.Instance.Win)
        {
            rig.velocity = Vector2.zero;
            return;
        }
        AIPaddleMove();
    }
    //AI movemnt
    //Chekcs if ball is higher than the paddle then do the magic
    public void AIPaddleMove()
    {
        //If paddle is lower than ball, move up
        if (gameObject.transform.position.y - Ball.transform.position.y < 0)
        {
            rig.velocity = Time.deltaTime * paddleSpeed * Vector3.up;
        }
        else
        {//else move down
            rig.velocity = Time.deltaTime * paddleSpeed * Vector3.down;
        }
    }

}
