using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private Dictionary<string, ItemData> _inventory = new();
    [SerializeField] private float _inventoryMaxSize;
    private float _currentInventorySize = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(ItemData newItem)
    {
        _inventory.Add(newItem.itemName, newItem);
    }
}
