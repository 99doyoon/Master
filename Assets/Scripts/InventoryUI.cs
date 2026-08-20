using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private ItemSlotUI itemSlotPrefab;
    [SerializeField] private Transform slotGrid;

    private bool isInventoryOn;

    private void Start()
    {
        inventory.OnInventoryChanged += RefreshInventory;
        RefreshInventory();
    }

    private void Update()
    {
        if (Keyboard.current.iKey.wasPressedThisFrame)
        {
            InventoryOnOff();
        }
    }

    public void InventoryOnOff()
    {
        isInventoryOn = !isInventoryOn;
        inventoryPanel.SetActive(isInventoryOn);
    }

    private void RefreshInventory()
    {
        foreach (Transform child in slotGrid)
        {
            Destroy(child.gameObject);
        }

        foreach (InventoryItem item in inventory.Items)
        {
            ItemSlotUI newSlot = Instantiate(itemSlotPrefab, slotGrid);
            newSlot.SendItemDataToUI(item, this);
        }
    }


    private void OnDestroy()
    {
        inventory.OnInventoryChanged -= RefreshInventory;
    }
}
