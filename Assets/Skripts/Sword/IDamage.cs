public interface IDamage
{
    public int GetDamage();

    public void ApplyDamage(ICanBeDamaged canBeDamaged);
}
