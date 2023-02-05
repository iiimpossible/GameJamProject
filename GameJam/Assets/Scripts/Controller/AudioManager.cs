using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource source;
    public AudioClip clip_start;
    public AudioClip clip_normalHack;
    public AudioClip clip_rootHack;
    public AudioClip clip_levelPass;

    private void Awake()
    {
        if (instance == null) instance = this;

    }

    public void Play(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }

    public void PlayStart()
    {
        source.clip = clip_start;
        source.Play();
    }

    public void PlayNormalHack()
    {
        source.clip = clip_normalHack;
        source.Play();
    }

    public void PlayRootHack()
    {
        source.clip = clip_rootHack;
        source.Play();
    }

    public void PlayLevelPass()
    {
        source.clip = clip_levelPass;
        source.Play();

    }
}
