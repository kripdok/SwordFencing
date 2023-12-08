using UnityEngine.Events;

public class TrainingEnemy : Enemy
{
    public event UnityAction StartAttackState;
    public event UnityAction FinishAttackState;

    public override void Initialize(EnemySword sword, EnemySound enemySound)
    {
        base.Initialize(sword, enemySound);

        StateMachine = new TrainingEnemyStateMachine(this);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        EventBus.Instance.Subscribe<StartTrainingAttackSignal>(ReactToStartedTrainingAttack);
        EventBus.Instance.Subscribe<FinishTrainingSignal>(ReactToFinishedTraining);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        
        EventBus.Instance.UnSubscribe<FinishTrainingSignal>(ReactToFinishedTraining);
    }

    private void ReactToFinishedTraining(FinishTrainingSignal signal)
    {
        StateMachine = new EnemyStateMachine(this,RuntimeStates);
        EventBus.Instance.UnSubscribe<StartTrainingAttackSignal>(ReactToStartedTrainingAttack);
        EventBus.Instance.UnSubscribe<FinishTrainingAttackSignal>(ReactToFinishedAttack);
    }

    private void ReactToStartedTrainingAttack(StartTrainingAttackSignal signal)
    {
        StartAttackState?.Invoke();
        EventBus.Instance.Subscribe<FinishTrainingAttackSignal>(ReactToFinishedAttack);
    }

    private void ReactToFinishedAttack(FinishTrainingAttackSignal signal)
    {
        FinishAttackState?.Invoke();
    }
}