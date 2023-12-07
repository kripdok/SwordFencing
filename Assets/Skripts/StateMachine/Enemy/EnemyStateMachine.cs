public class EnemyStateMachine : StateMachine
{
    public EnemyStateMachine(Enemy enemy, RuntimeStates runtime)
    {
        EnemyIdleState idle = new EnemyIdleState(this, runtime.Idle, enemy);
        EnemyAttackState attack = new EnemyAttackState(this, runtime.Attack, enemy);
        EnemyDefenseState defense = new EnemyDefenseState(this, runtime.Defense, enemy);
        EnemyStunState stun = new EnemyStunState(this, runtime.Stun, enemy);

        Add(idle);
        Add(attack);
        Add(defense);
        Add(stun);

        CorrectState = idle;
        CorrectState.Enter();
    }
}