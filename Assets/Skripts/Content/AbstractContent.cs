using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractContent<T> : ScriptableObject where T: class
{
    [SerializeField] protected List<T> _objects;

    public IEnumerable<T> Objects => _objects;
}
