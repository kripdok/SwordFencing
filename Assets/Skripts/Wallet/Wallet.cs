using System;

public class Wallet : ISubscriber, IService
{
    private IPersistentData _persistentData;
    private CoinsUI _coinsUI;

    public int EarnedCoins { get; private set; }

    public Wallet(CoinsUI coinsUI, IPersistentData persistentData)
    {
        _coinsUI = coinsUI;
        EarnedCoins = 0;
        _persistentData = persistentData;
        _coinsUI.DisplayCoins(_persistentData.PlayerData.Money);
    }

    public void OnEnables()
    {
        EventBus.Instance.Subscribe<AddCoinsSignal>(AddCoins);
    }

    public void OnDisables()
    {
        EventBus.Instance.UnSubscribe<AddCoinsSignal>(AddCoins);
    }

    private void AddCoins(AddCoinsSignal signal)
    {
        if (signal.Coins < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(signal.Coins));
        }

        EarnedCoins += signal.Coins;
        _persistentData.PlayerData.Money += signal.Coins;
        _coinsUI.DisplayCoins(_persistentData.PlayerData.Money);
    }

    public void SpendCoins (int price)
    {
        if (price < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(price));
        }

        _persistentData.PlayerData.Money -= price;
        _coinsUI.DisplayCoins(_persistentData.PlayerData.Money);
    }

    public bool IsEnoughCoinsToBuy(int number)
    {
        return _persistentData.PlayerData.Money > number;
    }
}