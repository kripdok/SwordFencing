using UnityEngine;

[CreateAssetMenu(fileName = "DuelingScenesLevelViewFactory", menuName = "Factory/DuelingScenesLevelViewFactory")]
public class DuelingScenesLevelViewFactory : AbstractViewFactory<DuelingScenesLevelView, ConcreteScene>
{
    [SerializeField] private DuelingScenesLevelView _prefab;

    public override DuelingScenesLevelView Get(ConcreteScene sceneName, Transform parent)
    {
        DuelingScenesLevelView instance = Instantiate(_prefab, parent);
        instance.Initialize(sceneName);
        return instance;
    }
}
