using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    public virtual void StartGame()
    {
        EventBus.Instance.Invoke(new GamePlaySignal());
        EventBus.Instance.Invoke(new EnablePlayerControlSignal());
        EventBus.Instance.Invoke(new PlayMusicSignal());
        ServiceLocator.Instance.Get<Pause>().StartGameTime();
        gameObject.SetActive(false);
    }
}
