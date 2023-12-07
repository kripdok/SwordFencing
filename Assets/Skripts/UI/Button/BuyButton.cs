using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class BuyButton : AbstractButton
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Color _lockColor;
    [SerializeField] private Color _unlockColor;

    private bool _isLock;

    public event UnityAction Click;

    public void UpdateText(int price) => _text.text = price.ToString();

    public void Lock()
    {
        _isLock = true;
        _text.color = _lockColor;
    }

    public void Unlock()
    {
        _isLock = false;
        _text.color = _unlockColor;
    }

    protected override void OnButtonClicked()
    {
        if (_isLock)
        {
            return;
        }

        Click?.Invoke();
    }
}
