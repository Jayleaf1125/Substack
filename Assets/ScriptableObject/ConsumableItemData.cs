using UnityEngine;

[CreateAssetMenu(fileName = "NewItemConsumable", menuName = "Inventory/Consumable Item")]
public class ConsumableItemData : ItemData
{
    public int value;

    public override void Use()
    {
        Debug.Log($"Consumed {itemName}. Restored {value}");
    }
}
