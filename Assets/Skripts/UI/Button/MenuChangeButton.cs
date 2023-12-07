using UnityEngine;

public class MenuChangeButton : AbstractButton
{
    [SerializeField] private Panel ClosedMenu;
    [SerializeField] private Panel OpendMenu;

    protected override void OnButtonClicked()
    {
        EventBus.Instance.Invoke(new ButtonClickSignal());
        ClosedMenu.ClosePanel();
        OpendMenu.OpenPanel();
    }
}
