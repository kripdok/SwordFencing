public class EnemyDiedSignal : ISignal
{
    public readonly Enemy Enemy;

    public EnemyDiedSignal(Enemy enemy)
    {
        Enemy = enemy;
    }
}