using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Timers", menuName = "Timers/WaningTimer")]
public class WaningTimer : AbstractTimer
{
    private float _maxTime = 20;
    private bool _isWork;

    public override void Initialize(TimerUI timerUI)
    {
        _isWork = true;
        TimerUI = timerUI;
        CorrectTime = _maxTime;
        ChangeTimerValue();
    }

    public override void Update()
    {
        ChangeTimerValue();

        if (CorrectTime <= 0&& _isWork)
        {
            EventBus.Instance.Invoke<PlayerLoseSignal>(new PlayerLoseSignal());
            _isWork=false;
        }
    }

    protected override void ChangeTimerValue()
    {
        CorrectTime -= Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(CorrectTime);
        TimerUI.DisplayVolumeOnScreen(time);
    }
}
