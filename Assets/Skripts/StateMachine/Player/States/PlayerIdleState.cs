public class PlayerIdleState : PlayerState
{
    private PlayerSwordAnimatorController _animatorController;

    public PlayerIdleState(PlayerStateMachine machine, PlayerSword sword) : base(machine)
    {
        _animatorController = sword.AnimatorController;
    }

    public override void Enter()
    {
        _animatorController.Idle();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
    }
}