using UnityEngine;

public class Swipe
{
    public Vector2 StartPosition { get; private set; }
    public Vector2 EndPosition { get; private set; }

    public Swipe(Vector2 startPosition, Vector2 endPosition)
    {
        StartPosition = startPosition;
        EndPosition = endPosition;
    }

    public Vector3 GetDirection()
    {
        return (EndPosition - StartPosition).normalized;
    }

    public Vector2 GetCenterOfVector()
    {
        return new Vector2((StartPosition.x + EndPosition.x) / 2, (StartPosition.y + EndPosition.y) / 2);
    }
}
