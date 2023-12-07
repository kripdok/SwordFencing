using UnityEngine;

public class RuntimeStates: MonoBehaviour
{
    [field:Range(0,10),SerializeField] public float Idle { get;private set; }
    [field: Range(0, 10),SerializeField] public float Attack { get; private set; }
    [field: Range(0, 10), SerializeField] public float Stun { get; private set; }
    [field: Range(0, 10), SerializeField] public float Defense { get; private set; }
}