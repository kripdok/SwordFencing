using System.Collections.Generic;
using UnityEngine.Events;

public class ShopPanel : AbstractViewPanel<ShopItemView, ShopItem>
{
    private OpenSkinsChecker _openSkinsChecker;
    private SelectedSkinChecker _selectedSkinChecker;

    public event UnityAction<ShopItemView> ItemViewClicked;

    public void Initialize(OpenSkinsChecker openSkinsChecker, SelectedSkinChecker selectedSkinChecker)
    {
        _openSkinsChecker = openSkinsChecker;
        _selectedSkinChecker = selectedSkinChecker;
    }

    public override void Show(IEnumerable<ShopItem> items)
    {
        Clear();

        foreach (ShopItem item in items)
        {
            ShopItemView spawnedItem = Factory.Get(item, ItemParent);

            spawnedItem.Click += OnViewClicked;

            spawnedItem.UnSelect();
            spawnedItem.UnHighLight();

            _openSkinsChecker.Visit(spawnedItem.Item);

            if (_openSkinsChecker.IsOpened)
            {
                _selectedSkinChecker.Visit(spawnedItem.Item);

                if (_selectedSkinChecker.IsSelected)
                {
                    spawnedItem.Select();
                    spawnedItem.HighLight();
                    ItemViewClicked?.Invoke(spawnedItem);
                }

                spawnedItem.UnLock();
            }
            else
            {
                spawnedItem.Lock();
            }

            Views.Add(spawnedItem);
        }
    }

    public void Select(ShopItemView itemView)
    {
        foreach(var item in Views)
        {
            item.UnSelect();
        }

        itemView.Select();
    }

    protected override void Clear()
    {
        foreach (ShopItemView item in Views)
        {
            item.Click -= OnViewClicked;
            Destroy(item.gameObject);
        }

        Views.Clear();
    }

    protected override void OnViewClicked(ShopItemView itemView)
    {
        Heighlight(itemView);
        ItemViewClicked?.Invoke(itemView);
    }

    private void Heighlight(ShopItemView shopItemView)
    {
        foreach(var item in Views)
        {
            item.UnHighLight();
        }

        shopItemView.HighLight();
    }
}