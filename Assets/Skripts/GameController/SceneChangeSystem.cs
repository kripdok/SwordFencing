using UnityEditor.SceneManagement;

public class SceneChangeSystem : ISubscriber
{
    public void OnEnables()
    {
        EventBus.Instance.Subscribe<SceneChangeSignal>(OnChangeScene,1);
    }

    public void OnDisables()
    {
        EventBus.Instance.UnSubscribe<SceneChangeSignal>(OnChangeScene);
        
    }

    private void OnChangeScene(SceneChangeSignal signal)
    {
        EventBus.Instance.Invoke(new RestartGameSignal());
        EditorSceneManager.LoadScene(signal.SceneName.name);
    }
}
