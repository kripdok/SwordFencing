using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private VolumeButton _efectVolumeButton;
    [SerializeField] private VolumeButton _musicVolumeButton;

    private IPersistentData _persistentData;

    public void Instantiate(IPersistentData persistentData)
    {
        _persistentData = persistentData;
        SetSoundVolume();
    }

    private void SetSoundVolume()
    {
        _efectVolumeButton.Instantiate(_persistentData);
        _musicVolumeButton.Instantiate(_persistentData);
    }
}