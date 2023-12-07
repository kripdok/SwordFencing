public class SelectedSkinChecker : IShopItemVisitor
{
    private IPersistentData _persistentData;

    public bool IsSelected { get; private set; }

    public SelectedSkinChecker(in IPersistentData persistentData) => _persistentData = persistentData;

    public void Visit(ShopItem shopItem)
    {
        Visit((dynamic)shopItem);
    }

    public void Visit(SwordSkinItem swordSkinItem)
    {
        IsSelected = _persistentData.PlayerData.SelectedSword == swordSkinItem.SkinType;
    }

    public void Visit(PointerSkinItem pointSkinItem)
    {
        IsSelected = _persistentData.PlayerData.SelectedPointer == pointSkinItem.SkinType;
    }
}
