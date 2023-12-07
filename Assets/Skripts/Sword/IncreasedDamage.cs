public class IncreasedDamage : IDamage
{
    private int factor = 2;

    public IDamage Damage {  get; private set; }

    public IncreasedDamage(IDamage damage)
    {
        Damage = damage;
    }

    public void ApplyDamage(ICanBeDamaged canBeDamaged)
    {
        canBeDamaged.TakeDamage(GetDamage());
    }

    public int GetDamage()
    {
        return Damage.GetDamage() * factor;
    }
}
