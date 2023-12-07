using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopCategoryButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _image;
    [SerializeField] private Color _selectColor;
    [SerializeField] private Color _unselectColor;

    public event UnityAction Click;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick); 
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    public void Select() => _image.color = _selectColor;

    public void UnSelect() => _image.color = _unselectColor;

    private void OnClick() => Click?.Invoke();
}
