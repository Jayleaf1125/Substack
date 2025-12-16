using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<ItemData> _inventory = new();
    [SerializeField] private float _inventoryMaxSize;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CanAddItem(ItemData newItem)
    {
        if (_inventory.Count >= _inventoryMaxSize)
        {
            Debug.LogWarning("Inventory is maxed");
            return false;
        }

        _inventory.Add(newItem);
        return true;
    }

    public bool HasKey(KeyItemData data)
    {
        foreach (ItemData item in _inventory)
        {
            if (item.itemName == data.itemName) return true;
        }

        return false;
    }
}
