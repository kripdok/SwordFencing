using UnityEngine;

public class ArenaGameOver : GameOver
{
    [SerializeField] private EnemyWinArenaGameOverMenu _enemyMenu;

    private void OnEnable()
    {
        EventBus.Instance.Subscribe<PlayerLoseSignal>(ReactToEnemyWin);
    }

    private void OnDisable()
    {
        EventBus.Instance.UnSubscribe<PlayerLoseSignal>(ReactToEnemyWin);
    }

    protected override void ReactToEnemyWin(PlayerLoseSignal signal)
    {
        Sound.PlayLoseClip();
        GameOverMenu = InstantiateMenu(_enemyMenu);
        ((EnemyWinArenaGameOverMenu)GameOverMenu).SetNumberOfCoinsWon(SetCoins());
        ((EnemyWinArenaGameOverMenu)GameOverMenu).SetNumberEnemyDied(SetEnemy());

        EventBus.Instance.Invoke(new GamePauseSignal());
        EventBus.Instance.Invoke(new FinishGameSignal());
    }

    private int SetCoins()
    {
        return ServiceLocator.Instance.Get<Wallet>().EarnedCoins;
    }

    private int SetEnemy()
    {
        return ServiceLocator.Instance.Get<EnemyDeathCounter>().Counter;
    }
}