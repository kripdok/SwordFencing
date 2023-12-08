using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSound", menuName = "Sound/PlayerSound")]
public class PlayerSound :AbstractSound
{
    [SerializeField] private List<AudioClip> _takeDamage;

    public void PlayTakingDamage()
    {
        int index = GetAudioSourceIndex(_takeDamage);
        PlaySound(_takeDamage[index]);
    }
}