using UnityEngine;

public class HashEnemySwordAnimation : HashSwordAnimation
{
    public readonly int IsBlock;
    public readonly int IsStun;
    public readonly int PrepareTrigger;
    public readonly int AttackTrigger;

    public HashEnemySwordAnimation() : base()
    {
        IsBlock = Animator.StringToHash("IsBlock");
        IsStun = Animator.StringToHash("IsStun");
        PrepareTrigger = Animator.StringToHash("PrepareTrigger");
        AttackTrigger = Animator.StringToHash("AttackTrigger");
    }
}
