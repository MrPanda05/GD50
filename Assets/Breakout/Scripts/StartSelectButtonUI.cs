using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class StartSelectButtonUI : MonoBehaviour
{
    [SerializeField]
    private int selected = 1;

    [SerializeField]
    private Button[] buttosUIs;

    [SerializeField]
    private TextMeshProUGUI[] textButtons;

    private void Awake()
    {
        buttosUIs = GetComponentsInChildren<Button>();
    }
    private void Start()
    {
        buttosUIs[selected].Select();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (selected >= buttosUIs.Length - 1)
            {
                selected = 0;
            }
            else
            {
                selected++;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (selected <= 0)
            {
                selected = buttosUIs.Length - 1;
            }
            else
            {
                selected--;
            }
        }
        buttosUIs[selected].Select();
        if (selected == 0)
        {
            textButtons[selected].color = new Color(0, 255, 255, 255);
            textButtons[selected + 1].color = new Color(255, 255, 255, 255);
        }
        else
        {
            textButtons[selected].color = new Color(0, 255, 255, 255);
            textButtons[selected - 1].color = new Color(255, 255, 255, 255);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            EventSystem.current.currentSelectedGameObject.GetComponent<Button>().onClick.Invoke();
        }
    }
}
