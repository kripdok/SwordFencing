using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractSound : ScriptableObject
{
    protected AudioSource AudioSource;

    public virtual void Initialize(AudioSource audioSource)
    {
        AudioSource = audioSource;
        AudioSource.playOnAwake = false;
        AudioSource.loop = false;
    }

    protected void PlaySound(AudioClip audioClip)
    {
        AudioSource.PlayOneShot(audioClip);
    }

    protected int GetAudioSourceIndex(IReadOnlyCollection<AudioClip> audioClips)
    {
        return Random.Range(0, audioClips.Count);
    }
}
