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
    private bool _isConsumeableItemInRange = false;


    void Start()
    {
        _uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
        _playerInventory = GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckItemInRange();

        _uiManager.IsPickupTextActive(_isConsumeableItemInRange);
        ConsumableItemPickup();
    }

    void ConsumableItemPickup()
    {
        if (!_isConsumeableItemInRange) return;

        Collider[] itemColliders = Physics.OverlapSphere(transform.position, _itemPickupRange, _itemLayer);

        if (itemColliders != null)
        {
            GameObject itemObj = itemColliders[0].gameObject;
            ConsumableItem item = itemObj.GetComponent<ConsumableItem>();

            if (Input.GetKeyDown(KeyCode.R))
            {
                ConsumableItemData itemData = item.GetConsumableItemInfo();
                _playerInventory.AddItem(itemData);
                _uiManager.DisplayPickupSuccess(itemData.itemName);
                Destroy(itemObj);
            }
        }
    }

    void CheckItemInRange() => _isConsumeableItemInRange = Physics.CheckSphere(transform.position, _itemPickupRange, _itemLayer);

    private void OnDrawGizmos()
    {
        Gizmos.color = _gizmoItemPickupRangeColor;
        Gizmos.DrawWireSphere(transform.position, _itemPickupRange);
    }
}
