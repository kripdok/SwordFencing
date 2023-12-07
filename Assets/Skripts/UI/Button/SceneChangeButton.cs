using UnityEngine;

public class SceneChangeButton : AbstractButton
{
    [SerializeField] protected ConcreteScene SceneName;

    protected override void OnButtonClicked()
    {
        EventBus.Instance.Invoke(new ButtonClickSignal());
        EventBus.Instance.Invoke(new SceneChangeSignal(SceneName));
    }
}