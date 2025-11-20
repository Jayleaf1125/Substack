using UnityEngine;

[CreateAssetMenu(fileName = "NewItemConsumable", menuName = "Inventory/Consumable Item")]
public class ConsumableItemData : ItemData
{
    public int healthRestoreAmount;

    public override void Use()
    {
        Debug.Log($"Consumed {itemName}. Restored {healthRestoreAmount}");
    }
}
