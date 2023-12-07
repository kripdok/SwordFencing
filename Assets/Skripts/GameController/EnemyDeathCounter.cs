public class EnemyDeathCounter : ISubscriber, IService
{
    public int Counter { get;private set; }

    public EnemyDeathCounter()
    {
        Counter = 0;
    }

    public void OnEnables()
    {
        EventBus.Instance.Subscribe<EnemyDiedSignal>(IncreaseCounter);
    }

    public void OnDisables()
    {
        EventBus.Instance.UnSubscribe<EnemyDiedSignal>(IncreaseCounter);
    }

    private void IncreaseCounter(EnemyDiedSignal signal)
    {
        Counter++;
    }
}