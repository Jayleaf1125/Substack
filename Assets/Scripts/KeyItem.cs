using Unity.VisualScripting;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    [SerializeField] private KeyItemData _keyItem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public KeyItemData GetKeyItemInfo() => _keyItem; 
}
