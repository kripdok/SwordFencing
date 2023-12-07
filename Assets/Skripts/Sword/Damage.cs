public class Damage : IDamage
{
    private int _danage;

    public Damage(int damage)
    {
        _danage = damage;
    }

    public void ApplyDamage(ICanBeDamaged canBeDamaged)
    {
        canBeDamaged.TakeDamage(GetDamage());
    }

    public int GetDamage()
    {
        return _danage;
    }
}
