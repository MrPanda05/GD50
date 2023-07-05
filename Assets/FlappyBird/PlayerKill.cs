using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerKill : MonoBehaviour
{
    public PlayerStats stats;

    public static event Action OnRestart;

    [SerializeField]
    private TextMeshProUGUI score;

    [SerializeField]
    private Image medal;

    [SerializeField]
    private Sprite noMedal, bronzeMedal, silverMedal, goldMedal;

    private void OnEnable()
    {
        score.text = stats.points.ToString();
        if(stats.points < 7)
        {
            medal.sprite = noMedal;
        }else if(stats.points >= 7 && stats.points < 15)
        {
            medal.sprite = bronzeMedal;
        }
        else if (stats.points >= 15 && stats.points < 24)
        {
            medal.sprite = silverMedal;
        }
        else
        {
            medal.sprite = goldMedal;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            stats.points = 0;
            gameObject.SetActive(false);
            OnRestart?.Invoke();
        }
    }
}
