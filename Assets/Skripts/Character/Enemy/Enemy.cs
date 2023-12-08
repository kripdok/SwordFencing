using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

[RequireComponent(typeof (AudioSource))]
public class Enemy : MonoBehaviour , ICanBeDamaged
{
    [field: SerializeField] public EnemyName Name { get; private set; }

    [SerializeField] protected RuntimeStates RuntimeStates;
    [SerializeField] private Transform _arm;
    [SerializeField] private int _health;
    [SerializeField] private int _coins;

    protected StateMachine StateMachine;
    private bool _isTakeDamage;


    public EnemySword Sword { get; private set; }
    public Swipe Swipe { get; private set; }
    public EnemySound Sound { get; private set; }
    public HealthSystem Health { get; private set; }

    public event UnityAction PlayerSwipeDetected;

    public virtual void Initialize(EnemySword sword, EnemySound enemySound)
    {
        Sword = sword;
        Sound = enemySound;
        Sound.Initialize(GetComponent<AudioSource>());
        Sword.transform.SetParent(_arm);
        Sword.transform.position = _arm.position;
        _isTakeDamage = false;


        if (Health == null)
        {
            Health = new HealthSystem(_health);
        }

            Health.Died += OnDeath;

        if(StateMachine == null)
        {
            StateMachine = new EnemyStateMachine(this, RuntimeStates);
        }
        
    }

    protected virtual void OnEnable()
    {
        EventBus.Instance.Subscribe<PlayerSwipedSignal>(OnPlayerSwiped,1);
        EventBus.Instance.Subscribe<PlayerSwordWasRepelledSignal>(RevokeDamage);
    }

    protected virtual void OnDisable()
    {
        Health.Died -= OnDeath;

        EventBus.Instance.UnSubscribe<PlayerSwipedSignal>(OnPlayerSwiped);
        EventBus.Instance.UnSubscribe<PlayerSwordWasRepelledSignal>(RevokeDamage);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerSword>(out PlayerSword sword) && sword.IsAttack)
        {
            _isTakeDamage = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerSword>(out PlayerSword sword) && sword.IsAttack)
        {
            if (_isTakeDamage)
            {
                Sound.PlayTakingDamage();
                sword.TakeDamage(this);
                _isTakeDamage = false;
            }
        }
    }

    private void Update()
    {
        StateMachine.Update();
    }

    private void OnPlayerSwiped(PlayerSwipedSignal signal)
    {
        Swipe = signal.Swipe;
        PlayerSwipeDetected?.Invoke();
    }

    private void RevokeDamage(PlayerSwordWasRepelledSignal signal)
    {
        _isTakeDamage = false;
    }

    private void OnDeath()
    {
        Sound.PlayDead();
        EventBus.Instance.Invoke(new EnemyDiedSignal(this));
        EventBus.Instance.Invoke(new AddCoinsSignal(_coins));
        EventBus.Instance.Invoke(new PlayerWinSignal());
    }

    public void TakeDamage(int damage)
    {
        transform.DOShakePosition(0.5f, 0.2f);
        Health.ReduceValue(damage);
    }
}