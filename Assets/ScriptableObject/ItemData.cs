using UnityEngine;

public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon = null;
    public string itemDescription;
    public bool isStackable;
    public int maxSize;

    public virtual void Use()
    {
        Debug.Log($"{itemName} has been used");
    }
}
