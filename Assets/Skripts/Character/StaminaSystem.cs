using System.Collections;
using UnityEngine;

public class StaminaSystem : VitalSigns
{
    private SliderBar _bar;
    private float _updateTime = 0.1f;
    private Coroutine coroutine;

    public StaminaSystem(int maxValue, SliderBar sliderBar) : base(maxValue)
    {
        _bar = sliderBar;
        _bar.SetSliderValue(ConcreteValue);
    }

    public override void ReduceValue(int number)
    {
        base.ReduceValue(number);
        _bar.SetSliderValue(ConcreteValue);

        if (coroutine != null)
        {
            Coroutines.StopRoutine(coroutine);
        }

        coroutine = Coroutines.StartRoutine(RetrieveValues());
    }

    public bool IsEnoughStaminaForAction(int action)
    {
        return ConcreteValue > action;
    }

    private IEnumerator RetrieveValues()
    {
        while(ConcreteValue != MaxValue)
        {
            ConcreteValue++;
            _bar.SetSliderValue(ConcreteValue);
            yield return new WaitForSeconds(_updateTime);
        }
    }
}