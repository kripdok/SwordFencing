using UnityEngine;

public class EnemySwordAnimationEventSystem : MonoBehaviour
{
    public void FinishAttack()
    {
        EventBus.Instance.Invoke(new EnemyHasStoppedAttackingSignal());
    }
}
