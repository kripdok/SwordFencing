using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<Y,T>: MonoBehaviour  where T: MonoBehaviour where Y : Enum
{
    protected Dictionary<Y, T> Objects;

    public void Initialize()
    {
        Objects = new Dictionary<Y, T>();
    }
    public abstract  T GetPrefab(T prefab);

    public abstract void Release(T obj);

    protected abstract T CreatePrefab(T obj);
}