using UnityEngine;

public abstract class AbstractViewFactory<T , Y> :ScriptableObject where T : class where Y : class
{
    public abstract T Get(Y prefab, Transform parent);
}