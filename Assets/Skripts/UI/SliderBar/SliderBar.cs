using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Slider))]
public class SliderBar : MonoBehaviour
{
    private Slider _slider;

    public void Initialize()
    {
        _slider = GetComponent<Slider>();
    }

    public void SetSliderValue(float value)
    {
        _slider.value = value / 100;
    }
}
