using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField]
    private GameObject upPipe, lowPipe;

    [SerializeField]
    private float heightOfPipes;

    private float spaceBetweenPipes;

    [SerializeField]
    private float speed;

    private float coin;

    private bool pipeTurn;// true for upper pipe, false for lower

    private void Start()
    {
        ChangePipePos();
    }
    private void Update()
    {
        if (!BirdStateMachine.Instance.PlayState || BirdStateMachine.Instance.LoseState || BirdStateMachine.Instance.PauseState)
        {
            return;
        }
        transform.position += Time.deltaTime * speed * Vector3.left;
    }

    //Shifts the pipes parent transformer to take care of the height
    //Shifts an individual pipe height based on the coin flip
    public void ChangePipePos()
    {
        if (!BirdStateMachine.Instance.PlayState || BirdStateMachine.Instance.LoseState || BirdStateMachine.Instance.PauseState)
        {
            return;
        }
        pipeTurn = CoinFlip();
        upPipe.transform.localPosition = new Vector3(0, 12, 0);
        lowPipe.transform.localPosition = new Vector3(0, -12, 0);
        transform.position = new Vector3(22, Random.Range(-heightOfPipes + 2, heightOfPipes), 0);//Height of all pipes
        if (pipeTurn)
        {
            upPipe.transform.localPosition -= new Vector3(0, Random.Range(0.1f, 0.5f), 0);
        }
        else
        {
            lowPipe.transform.localPosition += new Vector3(0, Random.Range(0.1f, 0.5f), 0);
        }
    }

    private bool CoinFlip()
    {
        coin = Random.Range(0f, 1f);
        if(coin < 0.5)
        {
            return true;
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PipeKill"))
        {
            Destroy(gameObject);
        }
    }
}
