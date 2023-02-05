using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip_start;
    public AudioClip clip_normalHack;
    public AudioClip clip_rootHack;
    public AudioClip clip_levelPass;

    public void Play(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
}
