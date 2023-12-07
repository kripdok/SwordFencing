using UnityEngine;

public class PlayerStateMachine : StateMachine , ISubscriber
{
    private StaminaSystem _stamina;
    private readonly int _attackStamina = 20;

    public Vector3 MultiTapPosition { get; private set; }
    public Swipe Swipe { get; private set; }

    public PlayerStateMachine(Player player)
    {
        _stamina = player.Stamina;

        PlayerIdleState idleState = new PlayerIdleState(this, player.Sword);
        PlayerAttackState attackState = new PlayerAttackState(this, player.Sword, player.Arm);
        PlayerDefenseState defenseState = new PlayerDefenseState(this, player) ;
        PlayerStunState stunState = new PlayerStunState(this, player.Sword, player.Arm);

        Add(idleState);
        Add(attackState);
        Add(defenseState);
        Add(stunState);

        CorrectState = idleState;
        CorrectState.Enter();
    }

    public void OnEnables()
    {
        EventBus.Instance.Subscribe<MultiTapSignal>(ReactToMultiTap);
        EventBus.Instance.Subscribe<PlayerSwipedSignal>(ReactToSwipe);
    }

    public void OnDisables()
    {
        EventBus.Instance.UnSubscribe<MultiTapSignal>(ReactToMultiTap);
        EventBus.Instance.UnSubscribe<PlayerSwipedSignal>(ReactToSwipe);
    }

    private void ReactToMultiTap(MultiTapSignal signal)
    {
        MultiTapPosition = signal.TapPosition;
        SetState<PlayerDefenseState>();
    }

    public void ReactToSwipe(PlayerSwipedSignal signal)
    {
        SetState<PlayerIdleState>();

        if (_stamina.IsEnoughStaminaForAction(_attackStamina))
        {
            _stamina.ReduceValue(_attackStamina);
            Swipe = signal.Swipe;
            SetState<PlayerAttackState>();
        }
    }
}