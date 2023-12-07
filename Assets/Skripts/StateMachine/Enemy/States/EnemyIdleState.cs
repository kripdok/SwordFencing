using UnityEngine;

public class EnemyIdleState : EnemyState
{
    private EnemySwordAnimatorController _animatorController;
    private Enemy _enemy;

    public EnemyIdleState(EnemyStateMachine machine,float runtime, Enemy enemy) : base(machine)
    {
        _enemy = enemy;
        _animatorController = _enemy.Sword.AnimatorController;
        Runtime = runtime;
    }

    public override void Enter()
    {
        _enemy.PlayerSwipeDetected += ReactToPlayerSwiped;
        ConcreteRuntime = Runtime;
        _animatorController.Idle();
    }

    public override void Update()
    {
        ConcreteRuntime -= Time.deltaTime;

        if (ConcreteRuntime < 0)
        {
            Machine.SetState<EnemyAttackState>();
        }
    }

    public override void Exit()
    {
        _enemy.PlayerSwipeDetected -= ReactToPlayerSwiped;
    }

    private void ReactToPlayerSwiped()
    {
        Machine.SetState<EnemyDefenseState>();
    }
}