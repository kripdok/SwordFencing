using UnityEngine;


public abstract class AbstractTimer : ScriptableObject
{
    protected TimerUI TimerUI;
    protected float CorrectTime;

    public abstract void Initialize(TimerUI timerUI);

    public abstract void Update();
    protected abstract void ChangeTimerValue();
}