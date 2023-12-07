using UnityEngine;

[CreateAssetMenu(fileName = "ShopItemViewFactory", menuName = "Factory/ShopItemViewFactory")]
public class ShopItemViewFactory : AbstractViewFactory<ShopItemView, ShopItem>
{
    [SerializeField] private ShopItemView _swordSkinItemPrefab;
    [SerializeField] private ShopItemView _pointerSkinItemPrefab;

    public override ShopItemView Get(ShopItem shopItem,Transform parent)
    {
        ShopItemVisitor visitor= new ShopItemVisitor(_swordSkinItemPrefab, _pointerSkinItemPrefab);
        visitor.Visit(shopItem);

        ShopItemView instance = Instantiate(visitor.Prefab, parent);
        instance.Initialize(shopItem);
        return instance;
    }

    private class ShopItemVisitor: IShopItemVisitor
    {
        private ShopItemView _swordSkinItemPrefab;
        private ShopItemView _pointerSkinItemPrefab;

        public ShopItemView Prefab { get; private set; }

        public ShopItemVisitor(ShopItemView swordSkinItemPrefab, ShopItemView pointerSkinItemPrefab)
        {
            _swordSkinItemPrefab = swordSkinItemPrefab;
            _pointerSkinItemPrefab = pointerSkinItemPrefab;
        }

        public void Visit(ShopItem shopItem)
        {
            Visit((dynamic)shopItem);
        }

        public void Visit(SwordSkinItem swordSkinItem)
        {
            Prefab = _swordSkinItemPrefab;
        }

        public void Visit(PointerSkinItem pointerSkinItem)
        {
            Prefab = _pointerSkinItemPrefab;
        }
    }
}