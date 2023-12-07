using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerPointerFactory", menuName = "Factory/PlayerPointerFactory")]
public class PlayerPointerFactory : ScriptableObject
{
    [SerializeField] private ContactPointer _red;
    [SerializeField] private ContactPointer _blue;

    public ContactPointer Get(PointerSkins skins)
    {
        var obj = Instantiate(GetPrefab(skins));
        return obj;
    }

    private ContactPointer GetPrefab(PointerSkins skins)
    {
        switch (skins)
        {
            case PointerSkins.Red:
                return _red;
            case PointerSkins.Blue:
                return _blue;
            default:
                throw new ArgumentException(nameof(skins));
        }
    }
}
