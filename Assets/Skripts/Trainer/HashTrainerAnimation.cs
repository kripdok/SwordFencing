using UnityEngine;

public class HashTrainerAnimation
{
    public readonly int IsAttack;
    public readonly int IsBlock;

    public HashTrainerAnimation()
    {
        IsAttack = Animator.StringToHash("IsAttack");
        IsBlock = Animator.StringToHash("IsBlock");
    }
}
