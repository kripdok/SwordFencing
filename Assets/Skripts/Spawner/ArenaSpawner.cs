using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyPool))]
[RequireComponent(typeof(EnemySwordPool))]

public class ArenaSpawner : Spawner
{
    [SerializeField] private ParticleSystem _appearanceEffect;
    [SerializeField] private List<Enemy> _enemyPrefabs;
    [SerializeField] private List<EnemySword> _swordPrefabs;
    [SerializeField] private float timeToWaitingSpawn = 1f;

    private EnemyPool _enemyPool;
    private EnemySwordPool _swordPool;
    private Enemy _enemy;

    public override void Initialize()
    {
        _enemyPool = GetComponent<EnemyPool>();
        _swordPool = GetComponent<EnemySwordPool>();
        _enemyPool.Initialize();
        _swordPool.Initialize();
        base.Initialize();
    }

    protected override void SpawnEnemy()
    {
        int enemyIndex = GetRandomIndex(_enemyPrefabs);
        int swordIndex = GetRandomIndex(_swordPrefabs);

        _enemy = _enemyPool.GetPrefab(_enemyPrefabs[enemyIndex]);
        var sword = _swordPool.GetPrefab(_swordPrefabs[swordIndex]);

        sword.Initialize();
        _enemy.Initialize(sword, EnemySound);

        _enemy.transform.position = EnemyPosition;
    }

    protected override void ReactToDeathEnemy(EnemyDiedSignal signal)
    {
        var enemy = signal.Enemy;
        _swordPool.Release(enemy.Sword);
        _enemyPool.Release(enemy);
        StartCoroutine(WaitingSpawnNextEnemy());
    }

    private int GetRandomIndex(ICollection collection)
    {
        return Random.Range(0, collection.Count);
    }

    private IEnumerator WaitingSpawnNextEnemy()
    {
        _appearanceEffect.Play();
        EventBus.Instance.Invoke(new DisablePlayerControlSignal());
        yield return new WaitForSeconds(timeToWaitingSpawn);
        EventBus.Instance.Invoke(new EnablePlayerControlSignal());
        SpawnEnemy();
    }
}