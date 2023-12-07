using UnityEngine;
using UnityEngine.Audio;

public class VolumeButton : AbstractButton
{
    [SerializeField] private AudioMixer _mixer;
    [field: SerializeField] public MixerName MixerName { get; private set; }

    private bool _isPlaying;
    private IPersistentData _data;
    private float _minVilume = -80;
    private float _volume = 0;

    public void Instantiate(IPersistentData persistentData)
    {
        _data = persistentData;
        _isPlaying = _data.SettingsData.GetMixerIsWork(MixerName);


        if (_isPlaying)
        {
            _mixer.SetFloat(MixerName.ToString(), _volume);
        }
        else
        {
            _mixer.SetFloat(MixerName.ToString(), _minVilume);
        }
        
    }

    protected override void OnButtonClicked()
    {
        if (_isPlaying)
        {
            _mixer.SetFloat(MixerName.ToString(), _minVilume);
            _isPlaying = false;
        }
        else
        {
            _mixer.SetFloat(MixerName.ToString(), _volume);
            _isPlaying = true;
        }

        _data.SettingsData.SetMixerIsWork(MixerName, _isPlaying);
    }
}
