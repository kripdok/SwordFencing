public class ServiceLocatorLoader_Arena : ServiceLocatorLoader 
{
    private Wallet _wallet;
    private EnemyDeathCounter _enemyDeathCounter;
    private Pause _pause;

    public override void Initialize(LevelManager levelManager)
    {
        _wallet = levelManager.Wallet;
        _enemyDeathCounter= levelManager.EnemyDeathCounter;
        _pause = new Pause();

        RegisterServices();
    }

    protected override void RegisterServices()
    {
        ServiceLocator.Instance.Register(_wallet);
        ServiceLocator.Instance.Register(_enemyDeathCounter);
        ServiceLocator.Instance.Register(_pause);
    }

    protected override void UnregisterServices(SceneChangeSignal signal)
    {
        ServiceLocator.Instance.Unregister<Wallet>();
        ServiceLocator.Instance.Unregister<EnemyDeathCounter>();
        ServiceLocator.Instance.Unregister<Pause>();
    }
}
