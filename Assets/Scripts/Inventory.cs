using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public ItemData itemData;
    public int count;

    public InventoryItem(ItemData itemData)
    {
        this.itemData = itemData;
        this.count = 1;
    }
}

public class Inventory : MonoBehaviour
{
    private List<InventoryItem> items = new List<InventoryItem>();

    public List<InventoryItem> Items {  get { return items; } }

    public event System.Action OnInventoryChanged;

    public void AddItem(ItemData itemData)
    {
        if (itemData == null)
        {
            Debug.LogWarning("추가하려는 ItemData가 없습니다.");
            return;
        }
        InventoryItem findItem = items.Find(x => x.itemData == itemData);

        if (findItem != null)
        {
            findItem.count++;
        }

        else
        {
            items.Add(new InventoryItem(itemData));
        }
        OnInventoryChanged?.Invoke();
    }

    public bool RemoveItem(ItemData itemData)
    {
        InventoryItem findItem = items.Find(x => x.itemData == itemData);

        if (findItem == null)
        {
            return false;
        }
        else if (findItem.count >= 2)
        {
            findItem.count--;
        }
        else
        {
            items.Remove(findItem);
        }
        OnInventoryChanged?.Invoke();
        return true;
    }

    public void GetItems()
    {

    }
}
