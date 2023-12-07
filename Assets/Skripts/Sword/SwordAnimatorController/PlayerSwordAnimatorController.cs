using UnityEngine;

public class PlayerSwordAnimatorController : AbstractSwordAnimatorController
{
    private HashPlayerSwordAnimation _hashAnimation;
    private Sword _sword;

    public PlayerSwordAnimatorController(Animator animator, Sword sword): base(animator) 
    {
        _sword = sword;
        _sword.gameObject.SetActive(false);
        _hashAnimation = new HashPlayerSwordAnimation();
    }

    public void Idle()
    {
        _animator.SetBool(_hashAnimation.IsBlock, false);
        _animator.SetBool(_hashAnimation.IsAttack, false);
        _sword.gameObject.SetActive(false);
    }

    public void Attack(Vector3 direction)
    {
        _sword.gameObject.SetActive(true);
        _animator.SetBool(_hashAnimation.IsAttack, true);
        SetDirection(direction);
    }

    public void Block(Vector2 direction)
    {
        _sword.gameObject.SetActive(true);
        _animator.SetBool(_hashAnimation.IsBlock, true);
        SetDirection(direction);
    }

    public void SetDirection(Vector2 direction)
    {
        _animator.SetFloat(_hashAnimation.BlendX, direction.x);
        _animator.SetFloat(_hashAnimation.BlendY, direction.y);
    }
}