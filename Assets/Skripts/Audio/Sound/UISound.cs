using UnityEngine;

[CreateAssetMenu(fileName = "UISound", menuName = "Sound/UISound")]
public class UISound : AbstractSound
{
    [SerializeField] private AudioClip _clickOnButton;
    [SerializeField] private AudioClip _buy;
    [SerializeField] private AudioClip _clickOnLockedButton;
    [SerializeField] private AudioClip _countdownTimer;

    public void PlayClickOnButton()
    {
        PlaySound(_clickOnButton);
    }

    public void PlayBuy()
    {
        PlaySound(_buy);
    }

    public void PlayClickOnLockedButton()
    {
        PlaySound(_clickOnLockedButton);
    }

    public void PlayCountdownTimer()
    {
        PlaySound(_countdownTimer);
    }
}
