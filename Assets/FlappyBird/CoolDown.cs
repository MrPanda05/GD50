using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoolDown : MonoBehaviour
{
    private TextMeshProUGUI counter;

    public static event Action OnCoolDownEnd, OnCoolDownEnter;

    private void Awake()
    {
        counter = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        StartCoroutine(Counter());
    }
    private void OnDisable()
    {
        OnCoolDownEnd?.Invoke();
    }

    IEnumerator Counter()
    {
        int count = 3;
        OnCoolDownEnter?.Invoke();
        counter.text = count.ToString();
        while (count > 0)
        {
            yield return new WaitForSecondsRealtime(0.75f);
            count--;
            counter.text = count.ToString();
        }
        gameObject.transform.parent.gameObject.SetActive(false);
        BirdStateMachine.Instance.PlayState = true;
        BirdStateMachine.Instance.StartState = false;
        BirdStateMachine.Instance.LoseState = false;
    }
}
