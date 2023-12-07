using UnityEngine;

public class SwipeDetection : ISubscriber
{
    private Vector2 _startPosition;
    private Vector2 _endPosition;
    private float _minDistance;
    private float _maxTime;
    private float _startTime;
    private float _endTime;

    private PlayerInput _input;

    public SwipeDetection(PlayerInput inputController, float minDistance, float maxTime)
    {
        _minDistance = minDistance;
        _maxTime = maxTime;
        _input = inputController;
    }

    public virtual void OnEnables()
    {
        _input.OnStartTouch += SwipeStart;
        _input.OnEndTouch += SwipeEnd;
        _input.OnMultiTap += DetectMultiTap;
    }

    public virtual void OnDisables()
    {
        _input.OnStartTouch -= SwipeStart;
        _input.OnEndTouch -= SwipeEnd;
        _input.OnMultiTap -= DetectMultiTap;
    }

    private void SwipeStart(Vector2 position, float time)
    {
        _startPosition = position;
        _startTime = time;
    }

    private void SwipeEnd(Vector2 position, float time)
    {
        _endPosition = position;
        _endTime = time;
        DetectSwipe();
    }

    protected virtual void DetectSwipe()
    {
        if (Vector2.Distance(_startPosition, _endPosition) > _minDistance && _endTime - _startTime < _maxTime)
        {
            Swipe swipe = new Swipe(_startPosition, _endPosition);

            EventBus.Instance.Invoke(new PlayerSwipedSignal(swipe));
        }
    }

    protected virtual void DetectMultiTap(Vector3 tapPosition)
    {
        EventBus.Instance.Invoke(new MultiTapSignal(tapPosition));
    }

}