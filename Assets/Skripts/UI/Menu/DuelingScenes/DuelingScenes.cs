using UnityEngine;
using System.Linq;

public class DuelingScenes : MonoBehaviour
{
    [SerializeField] private DuelingScenesContent _content;
    [SerializeField] private DuelingScenesPanel _panel;

    private OpenDuelingScenesChecker _checker;

    public void Initialize(IPersistentData persistentData)
    {
        _checker = new OpenDuelingScenesChecker(persistentData);
        _panel.Initialize(_checker);
        _panel.Show(_content.Objects.Cast<ConcreteScene>());
    }

    private void OnEnable()
    {
        _panel.LevelViewClicked += OnLevelViewCkicked;
    }

    private void OnDisable()
    {
        _panel.LevelViewClicked -= OnLevelViewCkicked;
    }

    private void OnLevelViewCkicked(DuelingScenesLevelView level)
    {
        if (level.IsLock == false)
        {
            EventBus.Instance.Invoke(new SceneChangeSignal(level.Scene));
        }
    }
}