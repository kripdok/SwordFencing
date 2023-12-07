using UnityEngine;

public class EnemyStunState : EnemyState
{
    private EnemySwordAnimatorController _animatorController;
    private EnemySound _sound;

    public EnemyStunState(EnemyStateMachine machine,float runtime, Enemy enemy) : base(machine)
    {
        _animatorController = enemy.Sword.AnimatorController;
        _sound = enemy.Sound;
        Runtime = runtime;
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
            Machine.SetState<EnemyIdleState>();
        }
    }
}