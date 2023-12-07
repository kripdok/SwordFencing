public abstract class PlayerState : State
{
    protected PlayerStateMachine Machine;
    public PlayerState(PlayerStateMachine machine)
    {
        Machine = machine;
    }
}
