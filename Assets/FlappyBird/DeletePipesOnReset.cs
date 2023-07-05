using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePipesOnReset : MonoBehaviour
{
    private GameObject[] pipes;

    private void OnEnable()
    {
        PlayerKill.OnRestart += DestroyAll;
    }
    private void OnDisable()
    {
        PlayerKill.OnRestart -= DestroyAll;
    }
    public void DestroyAll()
    {
        pipes = GameObject.FindGameObjectsWithTag("Pipes");
        foreach (GameObject enemy in pipes)
            Destroy(enemy);
    }
}
