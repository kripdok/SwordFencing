using UnityEngine;

public class CountdownTimerController : MonoBehaviour
{
    [SerializeField] private CountdownTimer _timer;
    [SerializeField] private Canvas _canvas;

    public void Initialize()
    {
        Instantiate(_timer, _canvas.transform);
        _timer.transform.position = Vector3.zero;
    }
}
