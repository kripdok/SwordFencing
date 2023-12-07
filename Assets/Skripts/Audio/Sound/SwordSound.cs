using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SwordSound", menuName = "Sound/SwordSound")]
public class SwordSound : AbstractSound
{
    [SerializeField] private List<AudioClip> _hits;
    [SerializeField] private List<AudioClip> _clashsWithSword;
    [SerializeField] private List<AudioClip> _blocks;

    public void PlayHitSound()
    {
        int index = GetAudioSourceIndex(_hits);
        PlaySound(_hits[index]);
    }

    public void PlayClashWithSword()
    {
        int index = GetAudioSourceIndex(_clashsWithSword);
        PlaySound(_clashsWithSword[index]);
    }

    public void PlayBlock()
    {
        int index = GetAudioSourceIndex(_blocks);
        PlaySound(_blocks[index]);
    }
}