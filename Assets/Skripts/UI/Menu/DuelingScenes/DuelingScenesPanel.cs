using System.Collections.Generic;
using UnityEngine.Events;

public class DuelingScenesPanel : AbstractViewPanel<DuelingScenesLevelView, ConcreteScene>
{
    private OpenDuelingScenesChecker _openDuelingScenesChecker;

    public event UnityAction<DuelingScenesLevelView> LevelViewClicked;

    public void Initialize(OpenDuelingScenesChecker openDuelingScenesChecker)
    {
        _openDuelingScenesChecker = openDuelingScenesChecker;
    }

    public override void Show(IEnumerable<ConcreteScene> enumerator)
    {
        Clear();

        foreach (ConcreteScene scene in enumerator)
        {
            DuelingScenesLevelView spawnedLevelView = Factory.Get(scene, ItemParent);

            spawnedLevelView.Click += OnViewClicked;

            spawnedLevelView.UnHighLight();

            _openDuelingScenesChecker.Visit(scene);

            if (_openDuelingScenesChecker.IsOpened)
            {
                spawnedLevelView.HighLight();
                spawnedLevelView.UnLock();
            }
            else
            {
                spawnedLevelView.Lock();
            }

            Views.Add(spawnedLevelView);
        }
    }

    protected override void Clear()
    {
        foreach (DuelingScenesLevelView item in Views)
        {
            item.Click -= OnViewClicked;
            Destroy(item.gameObject);
        }

        Views.Clear();
    }

    protected override void OnViewClicked(DuelingScenesLevelView itemView)
    {
        Heighlight(itemView);
        LevelViewClicked?.Invoke(itemView);
    }

    private void Heighlight(DuelingScenesLevelView shopItemView)
    {
        foreach (var item in Views)
        {
            item.UnHighLight();
        }

        shopItemView.HighLight();
    }
}