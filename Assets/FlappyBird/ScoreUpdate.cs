using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUpdate : MonoBehaviour
{
    private TextMeshProUGUI text;

    public PlayerStats stats;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        stats.points = 0;
        text.text = stats.points.ToString();
    }
    private void OnEnable()
    {
        PipeTrigg.OnPipePass += UpdateText;
        PlayerKill.OnRestart += ResetScore;
    }

    private void OnDisable()
    {
        PipeTrigg.OnPipePass -= UpdateText;
        PlayerKill.OnRestart -= ResetScore;
    }
    private void UpdateText()
    {
        stats.points++;
        text.text = stats.points.ToString();
    }
    public void ResetScore()
    {
        stats.points = 0;
        text.text = stats.points.ToString();
    }
}
