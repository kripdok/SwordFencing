public class AddCoinsSignal : ISignal
{
    public readonly int Coins;

    public AddCoinsSignal(int coins)
    {
        Coins = coins;
    }
}
