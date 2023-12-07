public class SkinUnLocker : IShopItemVisitor
{
    private IPersistentData _persistentData;

    public SkinUnLocker(in IPersistentData persistentData) => _persistentData = persistentData;

    public void Visit(ShopItem shopItem)
    {
        Visit((dynamic)shopItem);
    }

    public void Visit(SwordSkinItem swordSkinItem)
    {
        _persistentData.PlayerData.OpenSwordSkin(swordSkinItem.SkinType);
    }

    public void Visit(PointerSkinItem pointSkinItem)
    {
        _persistentData.PlayerData.OpenPointerSkin(pointSkinItem.SkinType);
    }
}
