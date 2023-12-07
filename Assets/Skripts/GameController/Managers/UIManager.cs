using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class UIManager : MonoBehaviour, ISubscriber
{
    [SerializeField] private UISound _sound;
    [SerializeField] private CoinsUI _coinsUI;
    [SerializeField] private MenuWindows _menuWindows;
    [SerializeField] private GameOver _gameOver;
    [SerializeField] private SliderBar _healthBar;
    [SerializeField] private SliderBar _staminaBar;
    [SerializeField] private TimerUI _timerUI;
    [SerializeField] private CountdownTimerController _countdownTimerController;

    public CoinsUI CoinsUI => _coinsUI;
    public TimerUI TimerUI => _timerUI;
    public SliderBar StaminaBar => _staminaBar;
    public SliderBar HealthBar => _healthBar;

    public void Initialize()
    {
        _sound.Initialize(GetComponent<AudioSource>());
        _gameOver.Initialize(_menuWindows);
        _healthBar.Initialize();
        _staminaBar.Initialize();
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