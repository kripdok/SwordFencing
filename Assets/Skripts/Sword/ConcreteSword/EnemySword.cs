using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnemySwordAnimationEventSystem))]
public class EnemySword : Sword
{
    [field: SerializeField] public EnemySwordName Name { get; private set; }
    public EnemySwordAnimatorController AnimatorController { get; private set; }

    public event UnityAction WasRepelled;

    public override void Initialize()
    {
        base.Initialize();
        IsAttack = false;
        AnimatorController = new EnemySwordAnimatorController(Animator);
    }

    private void OnEnable()
    {
        EventBus.Instance.Subscribe<EnemyHasStoppedAttackingSignal>(StopAttack);
    }

    private void OnDisable()
    {
        EventBus.Instance.UnSubscribe<EnemyHasStoppedAttackingSignal>(StopAttack);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerSword>(out PlayerSword sword))
        {
            Sound.PlayClashWithSword();
            EventBus.Instance.Invoke(new EnemySwordWasRepelledSignal());
            WasRepelled?.Invoke();
            IsAttack = false;
        }
    }

    private void StopAttack(EnemyHasStoppedAttackingSignal Signal)
    {
        IsAttack = false;
    }

}