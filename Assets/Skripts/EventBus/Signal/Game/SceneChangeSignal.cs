public class SceneChangeSignal : ISignal
{
    public readonly ConcreteScene SceneName;

    public SceneChangeSignal(ConcreteScene sceneName)
    {
        SceneName = sceneName;
    }
}
