using UnityEngine;

[CreateAssetMenu(fileName = "Music", menuName = "Sound/Music")]
public class Music : AbstractSound
{
    [SerializeField] private AudioClip _music;
    [SerializeField] private float _gamePauseVolume;

    public override void Initialize(AudioSource audioSource)
    {
        base.Initialize(audioSource);
        AudioSource.loop = true;
    }

    private void OnEnable()
    {
        EventBus.Instance.Subscribe<GamePlaySignal>(OnGamePlay);
        EventBus.Instance.Subscribe<GamePauseSignal>(OnGamePause);
    }

    private void OnDisable()
    {
        EventBus.Instance.UnSubscribe<GamePlaySignal>(OnGamePlay);
        EventBus.Instance.UnSubscribe<GamePauseSignal>(OnGamePause);
    }

    public void PlayMusic()
    {
        PlaySound(_music);
    }

    public void StopPlayMusic()
    {
        AudioSource.Stop();
    }

    private void OnGamePlay(GamePlaySignal signal)
    {
        AudioSource.volume = 1;
    }

    private void OnGamePause(GamePauseSignal signal)
    {
        AudioSource.volume = _gamePauseVolume;
    }
}