using UnityEngine;

public class EnemyDefenseState : EnemyState
{
    private Vector2 _direction;

    private Enemy _enemy;
    private EnemySword _sword;
    private EnemySwordAnimatorController _animatorController;

    public EnemyDefenseState(EnemyStateMachine machine, float runtime,Enemy enemy) : base(machine)
    {
        _enemy = enemy;
        _sword = _enemy.Sword;
        _animatorController = enemy.Sword.AnimatorController;
        Runtime = runtime;
    }

    public override void Enter()
    {
        _sword.WasRepelled += SetIdleState;
        _direction = _enemy.Swipe.GetCenterOfVector();
        _animatorController.Block(_direction);
        ConcreteRuntime = Runtime;
        _sword.Sound.PlayBlock();
    }

    public override void Update()
    {
        ConcreteRuntime -= Time.deltaTime;

        if (ConcreteRuntime < 0)
        {
            Machine.SetState<EnemyIdleState>();
        }
    }

    public override void Exit()
    {
        _sword.WasRepelled -= SetIdleState;
    }

    private void SetIdleState()
    {
        _enemy.Sound.PlayBlock();
        Machine.SetState<EnemyIdleState>();
    }
}