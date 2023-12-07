using UnityEngine;

public class PlayerDefenseState : PlayerState
{
    private PlayerSwordAnimatorController _animatorController;
    private PlayerSword _sword;
    private Vector3 _playerPosition;
    private Transform _arm;

    public PlayerDefenseState(PlayerStateMachine machine, Player player) : base(machine)
    {
        Runtime = player.DefenseRuntime;
        _sword = player.Sword;
        _animatorController = _sword.AnimatorController;
        _arm = player.Arm;
        _playerPosition = player.transform.position;
    }

    public override void Enter()
    {
        _sword.WasRepelled += RepelBack;

        _arm.transform.position = _playerPosition;
        _animatorController.Block(Machine.MultiTapPosition.normalized);
        ConcreteRuntime = Runtime;
        _sword.Sound.PlayBlock();
    }

    public override void Update()
    {
        ConcreteRuntime -= Time.deltaTime;

        if(ConcreteRuntime <= 0)
        {
            Machine.SetState<PlayerIdleState>();
        }
    }

    public override void Exit()
    {
        _sword.transform.position = _playerPosition;
        _sword.WasRepelled -= RepelBack;
    }

    public void RepelBack()
    {
        Machine.SetState<PlayerIdleState>();
    }
}