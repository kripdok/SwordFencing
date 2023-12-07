using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSound", menuName = "Sound/PlayerSound")]
public class PlayerSound :AbstractSound
{
    [SerializeField] private List<AudioClip> _takingDamage;

    public void PlayTakingDamage()
    {
        int index = GetAudioSourceIndex(_takingDamage);
        PlaySound(_takingDamage[index]);
    }
}