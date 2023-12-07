public class SkinSelector : IShopItemVisitor
{
    private IPersistentData _persistentData;

    public SkinSelector(in IPersistentData persistentData) => _persistentData = persistentData;

    public void Visit(ShopItem shopItem)
    {
        Visit((dynamic)shopItem);
    }

    public void Visit(SwordSkinItem swordSkinItem)
    {
        _persistentData.PlayerData.SelectedSword =swordSkinItem.SkinType;
    }

    public void Visit(PointerSkinItem pointSkinItem)
    {
        _persistentData.PlayerData.SelectedPointer= pointSkinItem.SkinType;
    }
}
