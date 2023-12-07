using UnityEngine;

public class LevelManager : MonoBehaviour, ISubscriber
{
    [SerializeField] private AttackBoostController _attackBoostController;
    [SerializeField] private BackgroundMusic _music;
    [SerializeField] private Player _player;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private PlayerSwordFactory _playerSwordFactory;
    [SerializeField] private PlayerPointerFactory _playerPointerFactory;
    [SerializeField] private AbstractTimer _timer;

    private PlayerSword _playerSword;
    private SceneChangeSystem _sceneChangeSystem;

    public Wallet Wallet { get; private set; }
    public ContactPointer ContactPointer { get; private set; }
    public Player Player => _player;
    public EnemyDeathCounter EnemyDeathCounter { get; private set; }

    public void Initialize(UIManager UIManager, IPersistentData persistentData)
    {
        _attackBoostController.Initialize();
        ContactPointer = _playerPointerFactory.Get(persistentData.PlayerData.SelectedPointer);
        _playerSword = _playerSwordFactory.Get(persistentData.PlayerData.SelectedSword, _player.Arm);
        _player.Initialize(_playerSword, UIManager.HealthBar, UIManager.StaminaBar);
        _spawner.Initialize();
        _music.Initialize();
        _sceneChangeSystem = new SceneChangeSystem();
        _timer.Initialize(UIManager.TimerUI);
        Wallet = new Wallet(UIManager.CoinsUI, persistentData);
        EnemyDeathCounter = new EnemyDeathCounter();
    }

    public void OnEnables()
    {
        _sceneChangeSystem.OnEnables();
        Wallet.OnEnables();
        _player.OnEnables();
        EnemyDeathCounter.OnEnables();
        _spawner.OnEnables();

        EventBus.Instance.Subscribe<FinishGameSignal>(CompleteLevel);
    }

    public void OnDisables()
    {
        _sceneChangeSystem.OnDisables();
        Wallet.OnDisables();
        _player.OnDisables();
        EnemyDeathCounter.OnDisables();
        _spawner.OnDisables();

        EventBus.Instance.UnSubscribe<FinishGameSignal>(CompleteLevel);
    }

    public void Update()
    {
        _timer.Update();
        _player.Updates();
    }

    private void CompleteLevel(FinishGameSignal signal)
    {
        _music.StopPlayMusic();
        ServiceLocator.Instance.Get<Pause>().StopGameTime();
    }
}