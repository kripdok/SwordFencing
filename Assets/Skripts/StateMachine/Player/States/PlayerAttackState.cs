using UnityEngine;

public class PlayerAttackState : PlayerState
{
    private PlayerSwordAnimatorController _animatorController;
    private Vector3 _direction;
    private PlayerSword _sword;
    private Transform _arm;
    private Swipe _swipe;
    private float _minDistance = 0.1f;

    public PlayerAttackState(PlayerStateMachine machine, PlayerSword sword, Transform arm) : base(machine)
    {
        _sword = sword;
        _arm = arm;
        _animatorController = _sword.AnimatorController;
    }

    public override void Enter()
    {
        _sword.WasRepelled += RepelBack;

        _swipe = Machine.Swipe;
        _direction = _swipe.GetDirection();
        _arm.transform.position = _swipe.StartPosition;
        _animatorController.Attack(_direction);
        _sword.LaunchAnAttack();
        _sword.Sound.PlayHitSound();
    }

    public override void Update()
    {
        if (Vector3.Distance(_arm.transform.position, _swipe.EndPosition) > _minDistance)
        {
            _arm.transform.position += _direction * _sword.Speed * Time.deltaTime;
        }
        else
        {
            Machine.SetState<PlayerIdleState>();
        }
    }

    public override void Exit()
    {
        _sword.StopAttack();
        _sword.WasRepelled -= RepelBack;
    }

    private void RepelBack()
    {
        Machine.SetState<PlayerStunState>();
    }
}