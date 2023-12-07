public class PlayerSwipedSignal : ISignal
{
    public readonly Swipe Swipe;

    public PlayerSwipedSignal(Swipe swipe)
    {
        Swipe = swipe;
    }
}
