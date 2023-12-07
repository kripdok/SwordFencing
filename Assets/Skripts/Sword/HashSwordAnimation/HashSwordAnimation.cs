using UnityEngine;

public class HashSwordAnimation
{
    public readonly int BlendX;
    public readonly int BlendY;

    public HashSwordAnimation()
    {
        BlendX = Animator.StringToHash("BlendX");
        BlendY = Animator.StringToHash("BlendY");
    }
}
