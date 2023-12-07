public class LevelMainMenuPanel : Panel
{
    public override void ClosePanel()
    {
        ServiceLocator.Instance.Get<Pause>().StartGameTime();
        EventBus.Instance.Invoke(new GamePlaySignal());
        base.ClosePanel();
    }

    public override void OpenPanel()
    {
        ServiceLocator.Instance.Get<Pause>().StopGameTime();
        EventBus.Instance.Invoke(new GamePauseSignal());
        base.OpenPanel();
    }
}
