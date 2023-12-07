using UnityEngine;

public class DuelGameOver : GameOver
{
    [SerializeField] private EnemyWinDuelGameOverMenu _enemyMenu;
    [SerializeField] private PlayerWinDuelGameOverMenu _playerMenu;


    private void OnEnable()
    {
        EventBus.Instance.Subscribe<PlayerWinSignal>(ReactToPlayerWin);
        EventBus.Instance.Subscribe<PlayerLoseSignal>(ReactToEnemyWin);
    }

    private void OnDisable()
    {
        EventBus.Instance.UnSubscribe<PlayerWinSignal>(ReactToPlayerWin);
        EventBus.Instance.UnSubscribe<PlayerLoseSignal>(ReactToEnemyWin);
    }

    protected override void ReactToEnemyWin(PlayerLoseSignal signal)
    {
        GameOverMenu = InstantiateMenu(_enemyMenu);

        Sound.PlayLoseClip();
        EventBus.Instance.Invoke(new GamePauseSignal());
        EventBus.Instance.Invoke(new FinishGameSignal());
    }

    private void ReactToPlayerWin(PlayerWinSignal signal)
    {
        Sound.PlayWinClip();
        GameOverMenu = InstantiateMenu(_playerMenu);
        ((PlayerWinDuelGameOverMenu)GameOverMenu).SetNumberOfCoinsWon(SetCoins());

        EventBus.Instance.Invoke(new GamePauseSignal());
        EventBus.Instance.Invoke(new FinishGameSignal());
    }

    private int SetCoins()
    {
        return ServiceLocator.Instance.Get<Wallet>().EarnedCoins;
    }
}