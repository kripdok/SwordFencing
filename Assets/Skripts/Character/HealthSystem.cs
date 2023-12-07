using UnityEngine.Events;

public class HealthSystem : VitalSigns
{
    public event UnityAction Died;

    public HealthSystem(int maxValue) : base(maxValue) { }

    public override void ReduceValue(int number)
    {
        base.ReduceValue(number);

        if(ConcreteValue <= 0)
        {
            Died?.Invoke();
        }
    }
}