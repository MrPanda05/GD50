using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlay : MonoBehaviour
{
    private AudioSource source;

    [SerializeField]
    private AudioClip Hit1, Hit2, Pass;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        PipeTrigg.OnPipePass += SoundOnPipePass;
        PipeColi.OnPipeHit += SoundOnHit;
    }
    private void OnDisable()
    {
        PipeTrigg.OnPipePass -= SoundOnPipePass;
        PipeColi.OnPipeHit -= SoundOnHit;
    }
    public void SoundOnPipePass()
    {
        source.PlayOneShot(Pass);
    }
    public void SoundOnHit()
    {
        source.PlayOneShot(Hit1);
        source.PlayOneShot(Hit2);
    }
}
