using UnityEngine;

public abstract class AbstractSwordAnimatorController
{
    protected Animator _animator;

    public AbstractSwordAnimatorController(Animator animator)
    {
        _animator = animator;
    }
}