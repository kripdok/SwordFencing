using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Timers",menuName = "Timers/IncreasingTimer")]
public class IncreasingTimer : AbstractTimer
{
    public override void Initialize(TimerUI timerUI)
    {
        TimerUI = timerUI;
        CorrectTime = 0;
        ChangeTimerValue();
    }

    public override void Update()
    {
        ChangeTimerValue();
    }

    protected override void ChangeTimerValue()
    {
        CorrectTime += Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(CorrectTime);
        TimerUI.DisplayVolumeOnScreen(time);
    }
}