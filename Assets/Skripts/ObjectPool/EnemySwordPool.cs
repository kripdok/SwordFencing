
public class EnemySwordPool : ObjectPool<EnemySwordName, EnemySword>
{
    public override EnemySword GetPrefab(EnemySword prefab)
    { 
        if (Objects.TryGetValue(prefab.Name, out EnemySword sword) == false)
        {
            sword = CreatePrefab(prefab);
        }

        sword.gameObject.SetActive(true);
        return sword;
    }

    public override void Release(EnemySword obj)
    {
        obj.gameObject.SetActive(false);
    }

    protected override EnemySword CreatePrefab(EnemySword prefab)
    {
        var obj = Instantiate(prefab, transform);
        Objects.Add(obj.Name, obj);
        return obj;
    }
}
