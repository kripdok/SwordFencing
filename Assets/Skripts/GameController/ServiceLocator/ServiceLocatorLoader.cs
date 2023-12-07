using UnityEngine;

public abstract class ServiceLocatorLoader : MonoBehaviour , ISubscriber
{
    public abstract void Initialize(LevelManager levelManager);

    public void OnEnables()
    {
        EventBus.Instance.Subscribe<SceneChangeSignal>(UnregisterServices);
    }

    public void OnDisables()
    {
        EventBus.Instance.UnSubscribe<SceneChangeSignal>(UnregisterServices);
    }

    protected abstract void RegisterServices();

    protected abstract void UnregisterServices(SceneChangeSignal signal);
}
