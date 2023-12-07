public class EnemyPool : ObjectPool<EnemyName,Enemy> , IService
{
    public override Enemy GetPrefab(Enemy prefab)
    {
        if (Objects.TryGetValue(prefab.Name, out Enemy enemy) == false)
        {
            enemy = CreatePrefab(prefab);
        }

        enemy.gameObject.SetActive(true);
        return enemy;
    }

    public override void Release(Enemy enemy)
    {
        enemy.Health.ResetMaxValue();
        enemy.gameObject.SetActive(false);
    }

    protected override Enemy CreatePrefab(Enemy prefab)
    {
        var obj = Instantiate(prefab, transform);
        Objects.Add(obj.Name, obj);
        return obj;
    }
}