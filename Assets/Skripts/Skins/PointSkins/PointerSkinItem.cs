using UnityEngine;

[CreateAssetMenu(fileName = "PointSkinItem", menuName = "Shop/PointSkinItem")]
public class PointerSkinItem : ShopItem
{
    [field: SerializeField] public PointerSkins SkinType { get; private set; }
}