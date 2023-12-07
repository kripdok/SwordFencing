using UnityEngine;

public class MultiTapSignal : ISignal
{
    public Vector3 TapPosition;

    public MultiTapSignal(Vector3 tapPosition)
    {
        TapPosition = tapPosition;
    }

}