using UnityEngine;

public class DataManager : MonoBehaviour
{
    private IPersistentData _persistentData;
    public PlayerDataLocalProvider PlayerProvider { get; private set; }
    public SettingsDataLocalProvider SettingsProvider { get; private set; }

    public IPersistentData PersistentData => _persistentData;

    public void Initialize()
    {
        _persistentData = new PersistentData();
        PlayerProvider = new PlayerDataLocalProvider(_persistentData);
        SettingsProvider = new SettingsDataLocalProvider(_persistentData);

        LoadDataOrInit();
    }

    public void Save()
    {
        PlayerProvider.Save();
        SettingsProvider.Save();
    }

    private void LoadDataOrInit()
    {
        if (PlayerProvider.TryLoad() == false)
        {
            _persistentData.PlayerData = new PlayerData();
        }

        if (SettingsProvider.TryLoad() == false)
        {
            _persistentData.SettingsData = new SettingsData();
        }
    }
}
