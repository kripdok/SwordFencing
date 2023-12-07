using UnityEngine;

public class MenuCloseButton : AbstractButton
{
    [SerializeField] private Panel _panel;

    protected override void OnButtonClicked()
    {
        EventBus.Instance.Invoke(new ButtonClickSignal());
        _panel.ClosePanel();
    }
}