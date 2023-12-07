using UnityEngine;

public class MenuOpenButton : AbstractButton
{
    [SerializeField] private Panel _panel;

    protected override void OnEnable()
    {
        base.OnEnable();
        EventBus.Instance.Subscribe<GamePauseSignal>(DisableButton);
        EventBus.Instance.Subscribe<GamePlaySignal>(EnableButton);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        EventBus.Instance.UnSubscribe<GamePauseSignal>(DisableButton);
        EventBus.Instance.UnSubscribe<GamePlaySignal>(EnableButton);
    }

    protected override void OnButtonClicked()
    {
        EventBus.Instance.Invoke(new ButtonClickSignal());
        _panel.OpenPanel();
    }

    private void EnableButton(GamePlaySignal signal)
    {
        Button.interactable = true;
    }

    private void DisableButton(GamePauseSignal signal)
    {
        Button.interactable = false;
    }
}