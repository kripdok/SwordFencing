using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractViewPanel<T,Y> : Panel where T : class where Y : class 
{
    [SerializeField] protected Transform ItemParent;
    [SerializeField] protected AbstractViewFactory<T,Y> Factory;

    protected List<T> Views = new List<T>();

    public abstract void Show(IEnumerable<Y> enumerator);

    protected abstract void Clear();

    protected abstract void OnViewClicked(T view);
}