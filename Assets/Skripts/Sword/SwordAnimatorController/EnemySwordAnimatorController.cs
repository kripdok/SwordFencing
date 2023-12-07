using UnityEngine;

public class EnemySwordAnimatorController : AbstractSwordAnimatorController
{
    private HashEnemySwordAnimation _hashAnimation;

    public EnemySwordAnimatorController(Animator animator) : base(animator)
    {
        _hashAnimation = new HashEnemySwordAnimation();
    }

    public void Idle()
    {
        _animator.SetBool(_hashAnimation.IsStun, false);
        _animator.SetBool(_hashAnimation.IsBlock, false);
    }


    public void Attack()
    {
        _animator.SetTrigger(_hashAnimation.AttackTrigger);
    }

    public void Stun()
    {
        _animator.SetBool(_hashAnimation.IsStun, true);
    }

    public void Block(Vector2 direction)
    {
        _animator.SetBool(_hashAnimation.IsBlock, true);
        SetDirection(direction);
    }

    public void PrepareToAttack(Vector2 direction)
    {
        _animator.SetTrigger(_hashAnimation.PrepareTrigger);
        SetDirection(direction);
    }

    public void SetDirection(Vector2 direction)
    {
        _animator.SetFloat(_hashAnimation.BlendX, direction.x);
        _animator.SetFloat(_hashAnimation.BlendY, direction.y);
    }
}