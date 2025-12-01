using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [Header("Item Pickup Range Parameters")]
    [SerializeField] private LayerMask _itemLayer;
    [SerializeField] private float _itemPickupRange;

    [Header("Gizmos Parameters")]
    [SerializeField] private Color _gizmoItemPickupRangeColor = Color.blue;

    private UIManager _uiManager;
    private PlayerInventory _playerInventory;

    private bool _isItemInRange = false;

    void Start()
    {
        _uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
        _playerInventory = GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfItemInRange();   

        _uiManager.IsPickupTextActive(_isItemInRange);
        ItemPickup();
    }

    void ItemPickup()
    {
        if (!_isItemInRange) return;

        Collider[] itemColliders = Physics.OverlapSphere(transform.position, _itemPickupRange, _itemLayer);

        if (itemColliders != null)
        {
            GameObject itemObj = itemColliders[0].gameObject;
            //Debug.Log(itemObj.name);
            HandlePickup(itemObj);
        }
    }

    void HandlePickup(GameObject itemObj)
    {
        if (Input.GetKeyDown(KeyCode.R) && itemObj.TryGetComponent<ConsumableItem>(out ConsumableItem conumeableItem))
        {
            ConsumableItemData itemData = conumeableItem.GetConsumableItemInfo();
            bool isPickupValid = _playerInventory.CanAddItem(itemData);
            if (isPickupValid)
            {
                _uiManager.DisplayPickupSuccess(itemData.itemName);
                Debug.Log("Consumeable Item has been picked up");
                Destroy(itemObj);
                return;
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && itemObj.TryGetComponent<KeyItem>(out KeyItem keyItem))
        {
            KeyItemData itemData = keyItem.GetKeyItemInfo();
            bool isPickupValid = _playerInventory.CanAddItem(itemData);

            if (isPickupValid)
            {
                _uiManager.DisplayPickupSuccess(itemData.itemName);
                Debug.Log("Key Item has been picked up");
                Destroy(itemObj);
                return;
            }
        }
    }

    void CheckIfItemInRange() => _isItemInRange = Physics.CheckSphere(transform.position, _itemPickupRange, _itemLayer);

    private void OnDrawGizmos()
    {
        Gizmos.color = _gizmoItemPickupRangeColor;
        Gizmos.DrawWireSphere(transform.position, _itemPickupRange);
    }
}
