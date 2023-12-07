using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySound", menuName = "Sound/EnemySound")]
public class EnemySound : AbstractSound
{
    [SerializeField] private List<AudioClip> _takingDamage;
    [SerializeField] private AudioClip _startOfSwing;
    [SerializeField] private AudioClip _stun;
    [SerializeField] private AudioClip _block;
    [SerializeField] private AudioClip _dead;

    public void PlayTakingDamage()
    {
        int index = GetAudioSourceIndex(_takingDamage);
        PlaySound(_takingDamage[index]);
    }

    public void PlayStartOfSwing()
    {
        PlaySound(_startOfSwing);
    }
    public void PlayStun()
    {
        PlaySound(_stun);
    }
    public void PlayBlock()
    {
        PlaySound(_block);
    }

    public void PlayDead()
    {
        PlaySound(_dead);
    }
}
