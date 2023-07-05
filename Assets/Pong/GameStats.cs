using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="PongStats")]
public class GameStats : ScriptableObject
{
    public int P1Score, P2Score;

    public float BallSpeed;

    public int WinScore;
}
