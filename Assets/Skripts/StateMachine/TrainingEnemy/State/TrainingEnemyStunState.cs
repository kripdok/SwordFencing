using UnityEngine;

public class TrainingEnemyStunState : TrainingEnemyState
{
    private EnemySwordAnimatorController _animatorController;
    private EnemySound _sound;

    public TrainingEnemyStunState(TrainingEnemyStateMachine machine, Enemy enemy) : base(machine)
    {
        _animatorController = enemy.Sword.AnimatorController;
        _sound = enemy.Sound;
        Runtime = 1f;
    }

    public override void Enter()
    {

        ConcreteRuntime = Runtime;
        _animatorController.Stun();
        _sound.PlayStun();
    }

    public override void Update()
    {
        ConcreteRuntime -= Time.deltaTime;

        if (ConcreteRuntime < 0)
        {
            Machine.SetState<TrainingEnemyIdleState>();
        }
    }

    public override void Exit()
    {
        EventBus.Instance.Invoke(new FinishTrainingSignal());
    }
}