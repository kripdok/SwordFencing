using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MainMenuUIManager : MonoBehaviour , ISubscriber
{
    [SerializeField] private UISound _sound;
    [field: SerializeField] public CoinsUI CoinsUI { get; private set; }

    public void Initialize()
    {
        _sound.Initialize(GetComponent<AudioSource>());
    }

    public void OnEnables()
    {
        EventBus.Instance.Subscribe<ButtonClickSignal>(OnButtonClicked);
    }

    public void OnDisables()
    {
        EventBus.Instance.UnSubscribe<ButtonClickSignal>(OnButtonClicked);
    }

    private void OnButtonClicked(ButtonClickSignal signal)
    {
        _sound.PlayClickOnButton();
    }
}
