using UnityEngine;

public class ConsumableItem : MonoBehaviour
{
    [SerializeField] private ConsumableItemData consumableItem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerInventory>().AddItem(consumableItem);
            Debug.Log($"{consumableItem.itemName} has been added to inventory");
            Destroy(this.gameObject);
        }
    }
}
