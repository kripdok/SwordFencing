using UnityEngine;

public class PlayerStunState : PlayerState
{
    private PlayerSword _sword;
    private Transform _arm;
    private Swipe _swipe;
    private Vector3 _direction;
    private float _minDistance = 0.1f;

    public PlayerStunState(PlayerStateMachine machine, PlayerSword sword, Transform arm) : base(machine)
    {
        _sword = sword;
        _arm = arm;
    }

    public override void Enter()
    {
        _swipe = Machine.Swipe;
        _direction = -_swipe.GetDirection();
    }

    public override void Update()
    {
        if (Vector3.Distance(_arm.transform.position, _swipe.StartPosition) > _minDistance)
        {
            _arm.transform.position += _direction * _sword.Speed * Time.deltaTime;
        }
        else
        {
            Machine.SetState<PlayerIdleState>();
        }
    }
}