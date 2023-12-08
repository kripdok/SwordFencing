using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour, ISubscriber , ICanBeDamaged
{
    [field: SerializeField] public PlayerSound Sound { get; private set; }
    [field: SerializeField] public Transform Arm { get; private set; }

    [SerializeField] private int _maxHealth;
    [SerializeField] private int _maxStamina;

    public readonly float DefenseRuntime = 1;
    private AudioSource _audioSource;
    private bool _isTakeDamage;

    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerHealthSystem Health { get; private set; }
    public StaminaSystem Stamina { get; private set; }
    public PlayerSword Sword { get; private set; }

    public void Initialize(PlayerSword sword, SliderBar healthBar, SliderBar staminaBar)
    {
        Sword = sword;
        _audioSource = GetComponent<AudioSource>();
        Sound.Initialize(_audioSource);

        Health = new PlayerHealthSystem(_maxHealth, healthBar);
        Stamina = new StaminaSystem(_maxStamina, staminaBar);
        StateMachine = new PlayerStateMachine(this);
    }

    public void OnEnables()
    {
        EventBus.Instance.Subscribe<EnemySwordWasRepelledSignal>(RevokeDamage);
        Sword.OnEnables();
        StateMachine.OnEnables();
        Health.Died += OnDied;
    }

    public void OnDisables()
    {
        EventBus.Instance.UnSubscribe<EnemySwordWasRepelledSignal>(RevokeDamage);
        StateMachine.OnDisables();
        StateMachine.OnDisables();
        Health.Died -= OnDied;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.TryGetComponent<EnemySword>(out EnemySword sword) && sword.IsAttack)
        {
            _isTakeDamage = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemySword>(out EnemySword sword) && sword.IsAttack)
        {
            if (_isTakeDamage)
            {
                Sound.PlayTakingDamage();
                sword.Damage.ApplyDamage(this);
                _isTakeDamage = false;
            }
        }
    }

    public void Updates()
    {
        StateMachine.Update();
    }

    private void OnDied()
    {
        EventBus.Instance.Invoke(new PlayerLoseSignal());
    }

    private void RevokeDamage(EnemySwordWasRepelledSignal signal)
    {
        _isTakeDamage = false;
    }

    public void TakeDamage(int damage)
    {
        Health.ReduceValue(damage);
    }
}