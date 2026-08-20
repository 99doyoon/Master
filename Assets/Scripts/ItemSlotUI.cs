using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private TextMeshProUGUI SellText;

    [SerializeField] private ItemData itemData;

    public void SendItemDataToUI(InventoryItem inventoryItem, InventoryUI inventoryUI)
    {
        itemData = inventoryItem.itemData;
        itemIcon.sprite = inventoryItem.itemData.Icon;
        itemNameText.text = inventoryItem.itemData.itemName;
        countText.text = inventoryItem.count.ToString();
        SellText.text = inventoryItem.itemData.SellPrice.ToString();
    }

    public void SellButton()
    {
        if (itemData == null)
        {
            return;
        }

        ShopManager.instance.SellItem(itemData);
    }
}
