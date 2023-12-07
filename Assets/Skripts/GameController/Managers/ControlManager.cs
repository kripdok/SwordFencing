using UnityEngine;

public class ControlManager : MonoBehaviour, ISubscriber
{
    [SerializeField] protected Camera Camera;

    protected float MinDistance = 0.2f;
    protected float MaxTime = 1f; 

    protected ContactPointerController ContactPointer; 
    protected SwipeDetection SwipeDetection;

    public virtual void Initialize(Player player, ContactPointer contactPointer)
    {
        PlayerInput.Instance.Initialize(Camera);

        ContactPointer = new ContactPointerController(PlayerInput.Instance, contactPointer);
        SwipeDetection = new SwipeDetection(PlayerInput.Instance, MinDistance, MaxTime);
    }

    public virtual void OnEnables()
    {
        PlayerInput.Instance.OnEnables();
        ContactPointer.OnEnables();
        SwipeDetection.OnEnables();

        EventBus.Instance.Subscribe<FinishGameSignal>(CompleteLevel,2);
    }

    public virtual void OnDisables()
    {
        PlayerInput.Instance.OnDisables();
        ContactPointer.OnDisables();
        SwipeDetection.OnDisables();

        EventBus.Instance.UnSubscribe<FinishGameSignal>(CompleteLevel);
    }

    private void CompleteLevel(FinishGameSignal signal)
    {
        PlayerInput.Instance.OnDisables();
    }
}