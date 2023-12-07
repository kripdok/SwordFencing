using UnityEngine;

public class HashPlayerSwordAnimation : HashSwordAnimation
{
    public readonly int IsAttack;
    public readonly int IsBlock;

    public HashPlayerSwordAnimation() : base()
    {
        IsAttack = Animator.StringToHash("IsAttack");
        IsBlock = Animator.StringToHash("IsBlock");
    }
}
