using UnityEngine;

[CreateAssetMenu(fileName = "AttackBoostSound", menuName = "Sound/AttackBoostSound")]
public class AttackBoostSound : AbstractSound
{
    [SerializeField] private AudioClip _instantiate;

    public void PlayInstantiate()
    {
        PlaySound(_instantiate);
    }
}
