using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Trainer : MonoBehaviour
{
    private HashTrainerAnimation _hashAnimation;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _hashAnimation = new HashTrainerAnimation();

    }

    private void OnEnable()
    {
        EventBus.Instance.Subscribe<StartTrainingSignal>(StartTraining);
        EventBus.Instance.Subscribe<FinishTrainingSignal>(FinishTraining);
        EventBus.Instance.Subscribe<StartTrainingAttackSignal>(StartBlockTraining);
    }

    private void OnDestroy()
    {
        EventBus.Instance.UnSubscribe<StartTrainingSignal>(StartTraining);
        EventBus.Instance.UnSubscribe<FinishTrainingSignal>(FinishTraining);
        EventBus.Instance.UnSubscribe<StartTrainingAttackSignal>(StartBlockTraining);
    }

    private void StartTraining(StartTrainingSignal signal)
    {
        _animator.SetBool(_hashAnimation.IsAttack, true);
    }

    private void StartBlockTraining(StartTrainingAttackSignal signal)
    {
        _animator.SetBool(_hashAnimation.IsAttack, false);
        gameObject.transform.position = new Vector2 (1, 1);
        _animator.SetBool(_hashAnimation.IsBlock, true);
    }

    private void FinishTraining(FinishTrainingSignal signal)
    {
        gameObject.SetActive(false);
    }
}
 