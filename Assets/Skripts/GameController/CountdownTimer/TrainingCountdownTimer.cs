public class TrainingCountdownTimer : CountdownTimer
{
    public override void StartGame()
    {
        EventBus.Instance.Invoke(new StartTrainingSignal());
        base.StartGame();
    }
}
