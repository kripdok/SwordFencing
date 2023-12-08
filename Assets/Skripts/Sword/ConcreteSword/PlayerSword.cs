using UnityEngine;
using UnityEngine.Events;

public class PlayerSword : Sword, ISubscriber
{
    public readonly float Speed = 15f;

    public PlayerSwordAnimatorController AnimatorController { get; private set; }

    public event UnityAction WasRepelled;

    public override void Initialize()
    {
        base.Initialize();
        IsAttack = false;
        AnimatorController = new PlayerSwordAnimatorController(Animator, this);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemySword>(out EnemySword sword))
        {
            Sound.PlayClashWithSword();
            EventBus.Instance.Invoke(new PlayerSwordWasRepelledSignal());
            WasRepelled?.Invoke();
            IsAttack = false;

            if (Damage is IncreasedDamage)
            {
                Damage = new Damage(_damage);
            }
        }
    }

    public void OnEnables()
    {
        EventBus.Instance.Subscribe<PlayerAttackBoostSignal>(BoostDamage);
    }

    public void OnDisables()
    {
        EventBus.Instance.UnSubscribe<PlayerAttackBoostSignal>(BoostDamage);
    }

    public void TakeDamage(ICanBeDamaged canBeDamaged)
    {
        canBeDamaged.TakeDamage(Damage.GetDamage());

        if(Damage is IncreasedDamage)
        {
            Damage = new Damage(_damage);
        }
    }

    private void BoostDamage(PlayerAttackBoostSignal signal)
    {
        Damage = new IncreasedDamage(Damage);
    }
}