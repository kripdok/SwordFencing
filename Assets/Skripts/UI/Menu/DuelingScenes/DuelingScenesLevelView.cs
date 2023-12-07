using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DuelingScenesLevelView : MonoBehaviour , IPointerClickHandler
{
    public event UnityAction<DuelingScenesLevelView> Click;

    [SerializeField] private Sprite _standartBackground;
    [SerializeField] private Sprite _highlightBackground;
    [SerializeField] private Image _lockImage;
    [SerializeField] private IntValueView _levelNumberView;

    private Image _backgroundImage;

    public ConcreteScene Scene { get; private set; }
    public bool IsLock { get; private set; }

    public void Initialize(ConcreteScene SceneName)
    {
        _backgroundImage = GetComponent<Image>();
        _backgroundImage.sprite = _standartBackground;

        Scene = SceneName;
        _levelNumberView.Show((int)Scene.Name);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Click?.Invoke(this);
    }

    public void Lock()
    {
        IsLock = true;
        _lockImage.gameObject.SetActive(IsLock);
    }

    public void UnLock()
    {
        IsLock = false;
        _lockImage.gameObject.SetActive(IsLock);
    }

    public void HighLight() => _backgroundImage.sprite = _highlightBackground;
    public void UnHighLight() => _backgroundImage.sprite = _standartBackground;
}