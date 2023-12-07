using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public abstract class Sword : MonoBehaviour
{
    [SerializeField] protected TrailRenderer Trail;

    [field:SerializeField] public SwordSound Sound { get; private set; }

    protected readonly int _damage = 10;

    protected Animator Animator;
    private AudioSource _audioSource;

    public IDamage Damage { get; protected set; }
    public bool IsAttack { get; protected set; }

    public virtual void Initialize()
    {
        Trail.gameObject.SetActive(false);
        Damage = new Damage(_damage);
        _audioSource = GetComponent<AudioSource>();
        Sound.Initialize(_audioSource);
        Animator = GetComponent<Animator>();
    }

    protected abstract void OnCollisionEnter2D(Collision2D collision);

    public void LaunchAnAttack()
    {
        Trail.gameObject.SetActive(true);
        IsAttack = true;
    }

    public void StopAttack()
    {
        Trail.gameObject.SetActive(false);
        IsAttack = false;
    }
}