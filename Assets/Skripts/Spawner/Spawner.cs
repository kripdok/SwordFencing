using UnityEngine;

public abstract class Spawner: MonoBehaviour , ISubscriber
{
    [SerializeField] protected Vector3 EnemyPosition;
    [SerializeField] protected EnemySound EnemySound;

    public void OnEnables()
    {
        EventBus.Instance.Subscribe<EnemyDiedSignal>(ReactToDeathEnemy);
    }

    public void OnDisables()
    {
        EventBus.Instance.UnSubscribe<EnemyDiedSignal>(ReactToDeathEnemy);
    }

    public virtual void Initialize()
    {
        SpawnEnemy();
    }
    protected abstract void SpawnEnemy();
    protected abstract void ReactToDeathEnemy(EnemyDiedSignal state);
}