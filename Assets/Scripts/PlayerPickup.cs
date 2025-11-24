using Unity.VisualScripting;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [Header("Item Pickup Range Parameters")]
    [SerializeField] private LayerMask _itemLayer;
    [SerializeField] private float _itemPickupRange;

    [Header("Gizmos Parameters")]
    [SerializeField] private Color _gizmoItemPickupRangeColor = Color.blue;

    [Header("Testing Parameters")]
    [SerializeField] private Material _itemSelectMat;
    private Material _originalMat;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsItemInRange())
        {
            Debug.Log("Item Detected");
            Collider[] itemColliders = Physics.OverlapSphere(transform.position, _itemPickupRange*10, _itemLayer);

            if (itemColliders != null)
            {
                Renderer _rend = itemColliders[0].gameObject.GetComponent<Renderer>();
                _originalMat = _rend.material;
                _rend.material = _itemSelectMat;

                ConsumableItemData item = itemColliders[0].gameObject.GetComponent<ConsumableItem>().GetConsumableItemInfo();
                
                if(Input.GetKeyDown(KeyCode.E))
                {
                    gameObject.GetComponent<PlayerInventory>().AddItem(item);
                    Debug.Log($"{item.itemName} has been added to inventory");
                    Destroy(itemColliders[0].gameObject);
                }



                Debug.Log(item.itemName);
            }
        }


}

    bool IsItemInRange() => Physics.CheckSphere(transform.position, _itemPickupRange, _itemLayer);

    void ItemCheck()
    {
        RaycastHit ll;

        if (Physics.SphereCast(transform.position, 100f, transform.position, out ll, 100f, _itemLayer))
        {
            Debug.Log("Item Check Hiot");
            //ConsumableItemData item = ll.collider.GetComponent<ConsumableItem>().GetConsumableItem();
            //Debug.Log(item.itemName);
        }
            
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _gizmoItemPickupRangeColor;
        Gizmos.DrawWireSphere(transform.position, _itemPickupRange);
    }
}
