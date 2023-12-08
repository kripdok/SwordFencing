using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class UIManager : MonoBehaviour, ISubscriber
{
    [field: SerializeField] public SliderBar HealthBar { get; private set; }
    [field: SerializeField] public SliderBar StaminaBar { get; private set; }
    [field: SerializeField] public TimerUI TimerUI { get; private set; }
    [field: SerializeField] public CoinsUI CoinsUI { get; private set; }

    [SerializeField] private UISound _sound;
    [SerializeField] private MenuWindows _menuWindows;
    [SerializeField] private GameOver _gameOver;
    [SerializeField] private CountdownTimerController _countdownTimerController;


    public void Initialize()
    {
        _sound.Initialize(GetComponent<AudioSource>());
        _gameOver.Initialize(_menuWindows);
        HealthBar.Initialize();
        StaminaBar.Initialize();
        _countdownTimerController.Initialize();

        _sound.PlayCountdownTimer();
    }

    public void OnEnables()
    {
        EventBus.Instance.Subscribe<FinishGameSignal>(CompleteLevel);
        EventBus.Instance.Subscribe<ButtonClickSignal>(OnButtonClicked);
    }

    public void OnDisables()
    {
        EventBus.Instance.UnSubscribe<FinishGameSignal>(CompleteLevel);
        EventBus.Instance.UnSubscribe<ButtonClickSignal>(OnButtonClicked);
    }

    private void CompleteLevel(FinishGameSignal signal)
    {
        _gameOver.OpenMenu();
    }

    private void OnButtonClicked(ButtonClickSignal signal)
    {
        _sound.PlayClickOnButton();
    }
}