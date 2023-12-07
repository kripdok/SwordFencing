using System.Linq;

public class OpenSkinsChecker : IShopItemVisitor
{
    private IPersistentData _persistentData;

    public bool IsOpened { get; private set; }

    public OpenSkinsChecker(in IPersistentData persistentData) => _persistentData = persistentData;

    public void Visit(ShopItem shopItem)
    {
        Visit((dynamic)shopItem);
    }

    public void Visit(SwordSkinItem swordSkinItem)
    {
        IsOpened = _persistentData.PlayerData.OpenSwordSkins.Contains(swordSkinItem.SkinType);
    }

    public void Visit(PointerSkinItem pointSkinItem)
    {
        IsOpened =_persistentData.PlayerData.OpenPointerSkins.Contains(pointSkinItem.SkinType);
    }
}