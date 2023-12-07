using UnityEngine;

public class EnemyAttackState: EnemyState
{
    private EnemySwordAnimatorController _animatorController;
    private EnemySword _sword;
    private EnemySound _sound;

    private bool _isAttack;


    public EnemyAttackState(EnemyStateMachine machine,float runtime, Enemy enemy) : base(machine)
    {
        _sword = enemy.Sword;
        _sound = enemy.Sound;
        _animatorController = enemy.Sword.AnimatorController;
        Runtime = runtime;
    }

    public override void Enter()
    {
        _isAttack = false;
        _sword.WasRepelled += ReactToSwordRepel;
        ConcreteRuntime = Runtime;
        Vector2 attackDirection = GetRandomAttackDirection();
        _animatorController.PrepareToAttack(attackDirection);
        _sound.PlayStartOfSwing();
    }

    public override void Update()
    {
        ConcreteRuntime -= Time.deltaTime;

        if(ConcreteRuntime < 0 && _isAttack != true)
        {
            _sword.LaunchAnAttack();
            _animatorController.Attack();
            _isAttack = true;
            _sword.Sound.PlayHitSound();
        }

        if (_sword.IsAttack == false && _isAttack)
        {
            Machine.SetState<EnemyIdleState>();
        }
    }

    public override void Exit()
    {
        _sword.StopAttack();
        _sword.WasRepelled -= ReactToSwordRepel;
    }

    private void ReactToSwordRepel()
    {
        Machine.SetState<EnemyStunState>();
    }

    private Vector2 GetRandomAttackDirection()
    {
        float maxDistance = 1f;
        return new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance));
    }
}