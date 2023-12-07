using UnityEngine;

public class TrainingEnemyIdleState : TrainingEnemyState
{
    private TrainingEnemy _enemy;

    public TrainingEnemyIdleState(TrainingEnemyStateMachine machine , TrainingEnemy enemy) : base(machine)
    {
        _enemy = enemy;
    }

    public override void Enter()
    {
        _enemy.StartAttackState +=ReactToStartedTrainingAttack;
    }

    public override void Exit()
    {
        _enemy.StartAttackState -= ReactToStartedTrainingAttack;
    }

    public void ReactToStartedTrainingAttack()
    {
        Machine.SetState<TrainingEnemyAttackState>();
    }
}
