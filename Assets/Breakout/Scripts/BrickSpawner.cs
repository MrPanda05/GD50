using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    //X offset by 1.6
    //Y offset by 0.7
    [SerializeField]
    private GameObject brick;

    [SerializeField]
    private int xMax, yMax;

    private void SpawnPattern1()
    {
        float xOffset = -8;
        float yOffset = 4;
        for(int i = 0; i < xMax; i++)
        {
            for (int j = 0; j < yMax; j++)
            {
                Instantiate(brick, new Vector3(xOffset, yOffset, 0), Quaternion.identity);
                xOffset += 1.6f;
            }
            yOffset -= 0.7f;
            xOffset = -8f;
        }
    }

    private void Start()
    {
        SpawnPattern1();
    }
}
