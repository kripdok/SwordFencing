using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private BackgroundMusic _backgroundMusic;
    [SerializeField] private DataManager _dataManager;
    [SerializeField] private MainMenuUIManager _UIManager;
    [SerializeField] private SettingsManager _settingsManager;
    [SerializeField] private Shop _shop;
    [SerializeField] private DuelingScenes _duelingScenes;

    private Wallet _wallet;
    private SceneChangeSystem _sceneChangeSystem;

    private void Awake()
    {
        _dataManager.Initialize();
        _UIManager.Initialize();
        _settingsManager.Instantiate(_dataManager.PersistentData);

        _sceneChangeSystem = new SceneChangeSystem();
        _wallet = new Wallet(_UIManager.CoinsUI, _dataManager.PersistentData);

        _shop.Initialize(_dataManager, _wallet);
        _duelingScenes.Initialize(_dataManager.PersistentData);
        _backgroundMusic.Initialize();
        EventBus.Instance.Invoke(new PlayMusicSignal());
    }

    private void OnEnable()
    {
        _sceneChangeSystem.OnEnables();
        _UIManager.OnEnables();
    }

    private void OnDisable()
    {
        _sceneChangeSystem.OnDisables();
        _UIManager.OnDisables();
    }
}