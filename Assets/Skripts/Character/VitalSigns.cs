using System;

public abstract class VitalSigns
{
    protected int MaxValue;
    public float ConcreteValue { get; protected set; }


    public VitalSigns(int maxValue)
    {
        MaxValue = maxValue;
        ConcreteValue = maxValue;
    }

    public virtual void ReduceValue(int number)
    {
        if (number < 0)
        {
            new ArgumentException("Number less than zero!");
        }

        ConcreteValue -= number;
    }

    public virtual void ResetMaxValue()
    {
        ConcreteValue = MaxValue;
    }
}
