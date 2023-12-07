public class TrainingEnemyStateMachine : StateMachine
{
    public TrainingEnemyStateMachine(TrainingEnemy enemy)
    {
        TrainingEnemyIdleState idle = new TrainingEnemyIdleState(this,enemy);
        TrainingEnemyStunState stun = new TrainingEnemyStunState(this, enemy);
        TrainingEnemyAttackState attack = new TrainingEnemyAttackState(this, enemy);

        Add(idle);
        Add(stun);
        Add(attack);

        CorrectState = idle;        
        CorrectState.Enter();
    }
}
