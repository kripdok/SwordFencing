using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private DataManager _dataManager;
    [SerializeField] private SettingsManager _settingsManager;
    [SerializeField] private UIManager _UIManager;
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private ControlManager _controlManager;
    [SerializeField] private ServiceLocatorLoader _locator;
    [SerializeField] private ConcreteScene _openScene;

    private bool _isPlayerWins;

    private void Awake()
    {
        _isPlayerWins = false;

        _dataManager.Initialize();
        _UIManager.Initialize();
        _settingsManager.Instantiate(_dataManager.PersistentData);
        _levelManager.Initialize(_UIManager, _dataManager.PersistentData);
        _controlManager.Initialize(_levelManager.Player, _levelManager.ContactPointer);
        _locator.Initialize(_levelManager);
    }

    private void Start()
    {
        EventBus.Instance.Invoke(new GamePauseSignal());
        EventBus.Instance.Invoke(new DisablePlayerControlSignal());
        ServiceLocator.Instance.Get<Pause>().StopGameTime();       
    }

    private void OnEnable()
    {
        _locator.OnEnables();
        _UIManager.OnEnables();
        _levelManager.OnEnables();
        _controlManager.OnEnables();

        EventBus.Instance.Subscribe<RestartGameSignal>(ChangeLevel);
        EventBus.Instance.Subscribe<FinishGameSignal>(CompleteLevel,1);
        EventBus.Instance.Subscribe<PlayerWinSignal>(ReactToPlayerWin , 1);
    }

    private void OnDisable()
    {
        _locator.OnDisables();
        _UIManager.OnDisables();
        _levelManager.OnDisables();
        _controlManager.OnDisables();

        EventBus.Instance.UnSubscribe<RestartGameSignal>(ChangeLevel);
        EventBus.Instance.UnSubscribe<FinishGameSignal>(CompleteLevel);
        EventBus.Instance.UnSubscribe<PlayerWinSignal>(ReactToPlayerWin);
    }

    private void CompleteLevel(FinishGameSignal signal)
    {
        if (_isPlayerWins)
        {
            _dataManager.PersistentData.PlayerData.OpenLevel(_openScene.Name);
        }

        EventBus.Instance.Invoke(new GamePauseSignal());
        _dataManager.Save();
    }

    private void ChangeLevel(RestartGameSignal signal)
    {
        _dataManager.Save();
    }

    private void ReactToPlayerWin(PlayerWinSignal signal)
    {
        _isPlayerWins = true;
    }
}