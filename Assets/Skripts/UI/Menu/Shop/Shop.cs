using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private SwordContent _swordItems;
    [SerializeField] private PointerContent _pointerItems;

    [SerializeField] private ShopCategoryButton _swordSkinsButton;
    [SerializeField] private ShopCategoryButton _pointerSkinsButton;

    [SerializeField] private BuyButton _buyButton;
    [SerializeField] private Button _selectionButton;
    [SerializeField] private Image _selectedText;

    [SerializeField] private ShopPanel _shopPanel;

    private DataManager _dataManager;
    private Wallet _wallet;
    private ShopItemView _previewedItem;
    private SkinSelector _skinsSelector;
    private SkinUnLocker _skinUnlocker;
    private OpenSkinsChecker _openSkinsChecker;
    private SelectedSkinChecker _selectedSkinChecker;


    public void Initialize(DataManager dataManager, Wallet wallet)
    {
        _dataManager = dataManager;
        _wallet = wallet;
        _skinsSelector = new SkinSelector(_dataManager.PersistentData);
        _skinUnlocker = new SkinUnLocker(_dataManager.PersistentData);
        _openSkinsChecker = new OpenSkinsChecker(_dataManager.PersistentData);
        _selectedSkinChecker = new SelectedSkinChecker(_dataManager.PersistentData);

        _shopPanel.Initialize(_openSkinsChecker, _selectedSkinChecker);

        OnSwordSkinsButtonClick();
    }
    private void OnEnable()
    {
        _pointerSkinsButton.Click += OnPointerSkinsButtonClick;
        _swordSkinsButton.Click += OnSwordSkinsButtonClick;
        _shopPanel.ItemViewClicked += OnItemViewCkicked;

        _buyButton.Click += OnBuyButtonClick;
        _selectionButton.onClick.AddListener(OnSelectionButtonClick);
    }

    private void OnDisable()
    {
        _pointerSkinsButton.Click -= OnPointerSkinsButtonClick;
        _swordSkinsButton.Click -= OnSwordSkinsButtonClick;
        _shopPanel.ItemViewClicked -= OnItemViewCkicked;

        _buyButton.Click -= OnBuyButtonClick;
        _selectionButton.onClick.RemoveListener(OnSelectionButtonClick);
    }

    private void OnItemViewCkicked(ShopItemView item)
    {
        _previewedItem = item;
        _openSkinsChecker.Visit(_previewedItem.Item);

        if (_openSkinsChecker.IsOpened)
        {
            _selectedSkinChecker.Visit(_previewedItem.Item);

            if (_selectedSkinChecker.IsSelected)
            {
                ShowSelectedText();
                return;
            }

            ShowSelectionButton();
        }
        else
        {
            ShowBuyButton(_previewedItem.Price);
        }
    }

    private void OnBuyButtonClick()
    {
        if (_wallet.IsEnoughCoinsToBuy(_previewedItem.Price))
        {
            _wallet.SpendCoins(_previewedItem.Price);
            _skinUnlocker.Visit(_previewedItem.Item);
            SelectSkin();
            _previewedItem.UnLock();
            _dataManager.Save();
        }
    }

    private void OnSelectionButtonClick()
    {
        SelectSkin();
        _dataManager.Save();
    }

    private void OnSwordSkinsButtonClick()
    {
        _swordSkinsButton.Select();
        _shopPanel.Show(_swordItems.Objects.Cast<ShopItem>());
    }

    private void OnPointerSkinsButtonClick()
    {
        _pointerSkinsButton.Select();
        _shopPanel.Show(_pointerItems.Objects.Cast<ShopItem>());
    }

    private void SelectSkin()
    {
        _skinsSelector.Visit(_previewedItem.Item);
        _shopPanel.Select(_previewedItem);
        ShowSelectedText();
    }

    private void ShowSelectionButton()
    {
        _selectionButton.gameObject.SetActive(true);
        HideBuyButton();
        HideSelectedText();
    }

    private void ShowSelectedText()
    {
        _selectedText.gameObject.SetActive(true);
        HideSelectedButton();
        HideBuyButton();
    }

    private void ShowBuyButton(int price)
    {
        _buyButton.gameObject.SetActive(true);
        _buyButton.UpdateText(price);

        if (_wallet.IsEnoughCoinsToBuy(price))
        {
            _buyButton.Unlock();
        }
        else
        {
            _buyButton.Lock();
        }

        HideSelectedButton();
        HideSelectedText();
    }

    private void HideBuyButton() => _buyButton.gameObject.SetActive(false);

    private void HideSelectedButton() => _selectionButton.gameObject.SetActive(false);

    private void HideSelectedText() => _selectedText.gameObject.SetActive(false);
}