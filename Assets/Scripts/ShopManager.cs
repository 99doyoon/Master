using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    [SerializeField] private List<ItemData> shopItems;
    [SerializeField] private PlayerMoney playerMoney;
    [SerializeField] private Inventory inventory;
    [SerializeField] private TMP_Text messageText;
    [SerializeField] private GameObject shopCanvas;

    private bool canOpenShop;

    bool shopActive;

    private Coroutine messageCoroutine;

    public bool CanOpenShop { get { return canOpenShop; } set { canOpenShop = value; } }

    public static event System.Action<bool> OnShopStateChanged;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        shopActive = false;
        shopCanvas.SetActive(false);
        messageText.gameObject.SetActive(false);
    }

    public void BuyItem(ItemData itemData)
    {
        if (itemData == null)
        {
            return;
        }

        if (playerMoney.SpendGold(itemData.BasePrice))
        {
            inventory.AddItem(itemData);
            ShowMessage(itemData.ItemName + " buy success!");
        }
        else
        {
            ShowMessage("You don't have enough gold!");
        }
    }

    private void Update()
    {
        if(Keyboard.current.eKey.wasPressedThisFrame && CanOpenShop)
        {
            if (shopActive == false)
            {
                shopCanvas.SetActive(true);
                shopActive = true;
            }
            else
            {
                shopCanvas.SetActive(false);
                shopActive = false;
            }
            OnShopStateChanged?.Invoke(shopActive);
        }
    }

    private void ShowMessage(string message)
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true);

        if (messageCoroutine != null)
        {
            StopCoroutine(messageCoroutine);
        }

        messageCoroutine = StartCoroutine(HideMessage());
    }

    private IEnumerator HideMessage()
    {
        yield return new WaitForSeconds(1.5f);

        messageText.gameObject.SetActive(false);
    }

    public void SellItem(ItemData itemData)
    {
        if (itemData == null)
        {
            return;
        }

        bool sellSuccess = inventory.RemoveItem(itemData);

        if (sellSuccess)
        {
            playerMoney.AddGold(itemData.SellPrice);
            ShowMessage(itemData.ItemName + " sell success!");
        }
    }
}
