using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSwordFactory", menuName = "Factory/PlayerSwordFactory")]
public class PlayerSwordFactory : ScriptableObject
{
    [SerializeField] private PlayerSword _red;
    [SerializeField] private PlayerSword _green;
    [SerializeField] private PlayerSword _blue;

    public PlayerSword Get(SwordSkins skins, Transform parents)
    {
        var sword = Instantiate(GetPrefab(skins), parents);
        sword.Initialize();
        return sword;
    }

    private PlayerSword GetPrefab(SwordSkins skins)
    {
        switch (skins)
        {
            case SwordSkins.Red:
                return _red;
            case SwordSkins.Green:
                return _green;
            case SwordSkins.Blue:
                return _blue;
            default:
                throw new ArgumentException(nameof(skins));
        }
    }
}
