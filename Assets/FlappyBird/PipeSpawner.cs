using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject pipePrefab;

    private GameObject copyPrefab;

    private float timer, randTime;
    private void Update()
    {
        if (!BirdStateMachine.Instance.PlayState || BirdStateMachine.Instance.LoseState) return;
        //spawn pipe after seconds
        if(timer > randTime)
        {
            SpawPipe();
            timer = 0;
        }
        timer += Time.deltaTime;
        randTime = Random.Range(1.5f, 2.5f);
    }

    //Spawn pipes and destroys it after 10 sec
    private void SpawPipe()
    {
        if (!BirdStateMachine.Instance.PlayState || BirdStateMachine.Instance.LoseState) return;
        copyPrefab = Instantiate(pipePrefab, new Vector3(22, 0, 0), Quaternion.identity);
    }
}
