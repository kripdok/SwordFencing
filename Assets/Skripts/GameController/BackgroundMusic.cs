using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private Music _music;

    public void Initialize()
    {
        _music.Initialize(GetComponent<AudioSource>());
    }

    private void OnEnable()
    {
        EventBus.Instance.Subscribe<PlayMusicSignal>(StartPlayMusic);
    }

    private void OnDisable()
    {
        EventBus.Instance.UnSubscribe<PlayMusicSignal>(StartPlayMusic);
    }

    public void StartPlayMusic(PlayMusicSignal signal)
    {
        _music.PlayMusic();
    }

    public void StopPlayMusic()
    {
        _music.StopPlayMusic();
    }
}
