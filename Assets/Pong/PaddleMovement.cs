using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    private Rigidbody2D rig;

    private float yMove;

    [SerializeField]private float paddleSpeed;


    public string buttonString;

    public bool isAi;



    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if (isAi)
        {
            this.enabled = false;
        }
    }

    private void Update()
    {
        yMove = Input.GetAxisRaw(buttonString);
    }

    private void FixedUpdate()
    {
        if (StateMachine.Instance.Serve || StateMachine.Instance.Win)
        {
            rig.velocity = Vector2.zero;
            return;
        }
        MovePaddle();
    }
    //Paddle Movemnt
    private void MovePaddle()
    {
        if (yMove > 0)
        {
            rig.velocity = Time.deltaTime * paddleSpeed * Vector3.up;
        }
        else if (yMove < 0)
        {
            rig.velocity = Time.deltaTime * paddleSpeed * Vector3.down;
        }
        else
        {
            rig.velocity = Vector2.zero;
        }
    }



}
