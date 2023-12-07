using UnityEngine;

public class TrainingEnemyAttackState : TrainingEnemyState
{
    private EnemySwordAnimatorController _animatorController;
    private EnemySword _sword;
    private EnemySound _sound;
    private TrainingEnemy _enemy;

    private bool _isAttack;
    private bool _isTrainingSignal;

    public TrainingEnemyAttackState(TrainingEnemyStateMachine machine, TrainingEnemy enemy) : base(machine)
    {
        _enemy = enemy;
        _sword = enemy.Sword;
        _sound = enemy.Sound;
        _animatorController = _sword.AnimatorController;
    }

    public override void Enter()
    {
        _isAttack = false;
        _isTrainingSignal = false;
        _sword.WasRepelled += ReactToSwordRepel;
        ConcreteRuntime = Runtime;
        Vector2 attackDirection = new Vector2(1,1);
        _animatorController.PrepareToAttack(attackDirection);
        _sound.PlayStartOfSwing();
        _enemy.FinishAttackState += ReactToFinishedAttack;
    }

    public override void Update()
    {
        if (_isTrainingSignal)
        {
            _sword.LaunchAnAttack();
            _animatorController.Attack();
            _isTrainingSignal = false;
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
        _enemy.FinishAttackState -= ReactToFinishedAttack;
    }

    public void ReactToSwordRepel()
    {
        Machine.SetState<TrainingEnemyStunState>();
    }

    private void ReactToFinishedAttack()
    {
        _isTrainingSignal = true;
    }
}