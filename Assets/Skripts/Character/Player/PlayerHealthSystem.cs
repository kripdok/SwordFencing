public class PlayerHealthSystem : HealthSystem
{
    private SliderBar _bar;

    public PlayerHealthSystem(int maxValue , SliderBar healthBar) : base(maxValue)
    {
        _bar = healthBar;
        _bar.SetSliderValue(ConcreteValue);
    }

    public override void ReduceValue(int number)
    {
        base.ReduceValue(number);
        _bar.SetSliderValue(ConcreteValue);
    }

    public override void ResetMaxValue()
    {
        base.ResetMaxValue();
        _bar.SetSliderValue(ConcreteValue);
    }
}