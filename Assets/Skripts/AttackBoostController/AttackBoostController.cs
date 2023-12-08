using System.Collections;
using UnityEngine;

public class AttackBoostController : MonoBehaviour
{
    [SerializeField] private AttackBoost _prefab;
    [SerializeField] private float _waitingTimeToSpawn;

    [SerializeField] private Vector2 _maxSpawnLimit;
    [SerializeField] private Vector2 _minxSpawnLimit;

    private float _concreteWaitingTime;

    private AttackBoost _boost;

    public void Initialize()
    {
        _boost = Instantiate(_prefab);
        _boost.Initialize();
        _boost.gameObject.SetActive(false);
        _concreteWaitingTime = _waitingTimeToSpawn;
    }

    private void OnEnable()
    {
        EventBus.Instance.Subscribe<GamePlaySignal>(EnableSpawn);
        EventBus.Instance.Subscribe<GamePauseSignal>(DisableSpawn);
    }

    private void OnDisable()
    {
        EventBus.Instance.UnSubscribe<GamePlaySignal>(EnableSpawn);
        EventBus.Instance.UnSubscribe<GamePauseSignal>(DisableSpawn);
    }

    private void EnableSpawn(GamePlaySignal signal)
    {
        Spawn();
    }

    private void DisableSpawn(GamePauseSignal signal)
    {
        StopCoroutine(WaitingSpawn());
    }

    private void Spawn()
    {
        StartCoroutine(WaitingSpawn());
    }

    private IEnumerator WaitingSpawn()
    {
        while (_concreteWaitingTime > 0)
        {
            _concreteWaitingTime -= Time.deltaTime;
            yield return null;
        }

        _concreteWaitingTime = _waitingTimeToSpawn;
        InitializedBoost();
        Spawn();
    }

    private void InitializedBoost()
    {
        float XExcise = Random.Range(_maxSpawnLimit.x, _minxSpawnLimit.x);
        float YExcise = Random.Range(_maxSpawnLimit.y, _minxSpawnLimit.y);

        _boost.Spawn(new Vector2(XExcise, YExcise));
    }
}