public class TrainerControlManager : ControlManager
{
    public override void Initialize(Player player, ContactPointer contactPointer)
    {
        PlayerInput.Instance.Initialize(Camera);

        ContactPointer = new ContactPointerController(PlayerInput.Instance, contactPointer);
        SwipeDetection = new TrainingSwipeDetection(PlayerInput.Instance, MinDistance, MaxTime);
    }

    public override void OnEnables()
    {
        base.OnEnables();
        EventBus.Instance.Subscribe<FinishTrainingSignal>(ReactToFinishTraining);
    }

    public override void OnDisables()
    {
        base.OnDisables();
        EventBus.Instance.UnSubscribe<FinishTrainingSignal>(ReactToFinishTraining);
    }

    private void ReactToFinishTraining(FinishTrainingSignal signal)
    {
        SwipeDetection = new SwipeDetection(PlayerInput.Instance, MinDistance, MaxTime);
    }
}