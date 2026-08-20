using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    None,
    Heal,
    SpeedUp
}

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObject/ItemData")]
public class ItemData : ScriptableObject
{
    public int itemId;
    public string itemName;
    public string description;
    public Sprite icon;

    public float effectValue;

    [SerializeField] private int basePrice;

    public int ItemId => itemId;
    public string ItemName => itemName;
    public string Description => description;
    public Sprite Icon => icon;
    public float EffectValue => effectValue;

    public int BasePrice => basePrice;
    public int SellPrice => basePrice / 2;
}
