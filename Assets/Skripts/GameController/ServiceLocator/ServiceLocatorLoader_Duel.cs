public class ServiceLocatorLoader_Duel : ServiceLocatorLoader
{
    private Wallet _wallet;
    private Pause _pause;

    public override void Initialize(LevelManager levelManager)
    {
        _wallet = levelManager.Wallet;
        _pause = new Pause();

        RegisterServices();
    }

    protected override void RegisterServices()
    {
        ServiceLocator.Instance.Register(_wallet);
        ServiceLocator.Instance.Register(_pause);
    }

    protected override void UnregisterServices(SceneChangeSignal signal)
    {
        ServiceLocator.Instance.Unregister<Wallet>();
        ServiceLocator.Instance.Unregister<Pause>();
    }
}