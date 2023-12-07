using UnityEngine;

public class DuelSpawner : Spawner
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private EnemySword _swordPrefab;

    private Enemy _enemy;

    protected override void SpawnEnemy()
    {
        _enemy = Instantiate(_enemyPrefab, EnemyPosition,Quaternion.identity);
        var sword = Instantiate(_swordPrefab);
        sword.Initialize();
        _enemy.Initialize(sword, EnemySound);
    }
    protected override void ReactToDeathEnemy(EnemyDiedSignal state)
    {
        _enemy = state.Enemy;
        _enemy.gameObject.SetActive(false);
    }
}