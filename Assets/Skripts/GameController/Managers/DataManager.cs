using UnityEngine;

public class DataManager : MonoBehaviour
{
    public IPersistentData PersistentData { get; private set; }
    public PlayerDataLocalProvider PlayerProvider { get; private set; }
    public SettingsDataLocalProvider SettingsProvider { get; private set; }

    public void Initialize()
    {
        PersistentData = new PersistentData();
        PlayerProvider = new PlayerDataLocalProvider(PersistentData);
        SettingsProvider = new SettingsDataLocalProvider(PersistentData);

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
            PersistentData.PlayerData = new PlayerData();
        }

        if (SettingsProvider.TryLoad() == false)
        {
            PersistentData.SettingsData = new SettingsData();
        }
    }
}