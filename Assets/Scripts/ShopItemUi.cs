using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemUi : MonoBehaviour
{
    [SerializeField] ItemData shopItem;

    [SerializeField] ShopManager shopManager;

    [SerializeField] private Image itemIcon;
    [SerializeField] private TMP_Text itemNameText;
    [SerializeField] private TMP_Text itemPriceText;

    private void Start()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        itemIcon.sprite = shopItem.Icon;
        itemNameText.text = shopItem.ItemName;
        itemPriceText.text = shopItem.BasePrice.ToString();
    }

    public void BuyButton()
    {
        // shopManager에게 현재 shopItem 구매 요청
        shopManager.BuyItem(shopItem);
    }
}
