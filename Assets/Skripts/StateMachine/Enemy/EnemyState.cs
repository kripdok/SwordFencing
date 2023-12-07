public abstract class EnemyState : State
{
    protected EnemyStateMachine Machine;
    public EnemyState(EnemyStateMachine machine)
    {
        Machine = machine;
    }
}