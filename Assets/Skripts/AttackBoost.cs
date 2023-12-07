using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]
public class AttackBoost : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private AttackBoostSound _sound;
    [SerializeField] private float _waitingTime;

    public void Initialize()
    {
        _sound.Initialize(GetComponent<AudioSource>());
    }

    public void Spawn(Vector2 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
        _sound.PlayInstantiate();
        StartCoroutine(WaitingForDisable());
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        EventBus.Instance.Invoke(new PlayerAttackBoostSignal());
        gameObject.SetActive(false);
        StopCoroutine(WaitingForDisable());
    }

    private IEnumerator WaitingForDisable()
    {
        yield return new WaitForSeconds(_waitingTime);
        gameObject.SetActive(false);
    }

}
