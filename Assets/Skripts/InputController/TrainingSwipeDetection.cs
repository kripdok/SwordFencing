using UnityEngine;

public class TrainingSwipeDetection : SwipeDetection
{
    public TrainingSwipeDetection(PlayerInput inputController, float minDistance, float maxTime) : base(inputController, minDistance, maxTime)
    {
    }

    public override void OnEnables()
    {
        base.OnEnables();
    }

    public override void OnDisables()
    {
        base.OnDisables();
    }


    protected override void DetectSwipe()
    {
        base.DetectSwipe();
        EventBus.Instance.Invoke(new StartTrainingAttackSignal());
    }

    protected override void DetectMultiTap(Vector3 tapPosition)
    {
        base.DetectMultiTap(tapPosition);
        EventBus.Instance.Invoke(new FinishTrainingAttackSignal());
    }
}
