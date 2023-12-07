using UnityEngine;

[CreateAssetMenu(fileName ="SwordSkinItem", menuName = "Shop/SwordSkinItem")]
public class SwordSkinItem : ShopItem
{
    [field: SerializeField] public SwordSkins SkinType { get; private set; }
}
