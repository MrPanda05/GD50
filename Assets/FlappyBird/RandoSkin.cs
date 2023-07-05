using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandoSkin : MonoBehaviour
{
    private SpriteRenderer render;

    [SerializeField]
    private Sprite[] skins;

    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        PlayerKill.OnRestart += RandomizeSkin;
    }
    private void OnDisable()
    {
        PlayerKill.OnRestart -= RandomizeSkin;
    }

    private void RandomizeSkin()
    {
        int randInt = Random.Range(0, skins.Length);
        render.sprite = skins[randInt];
    }
}
