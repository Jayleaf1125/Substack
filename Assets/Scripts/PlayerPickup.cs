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

    private UIManager _uiManager;
    private bool _isItemInRange = false;
    private PlayerInventory _playerInventory;




    void Start()
    {
        _uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
        _playerInventory = GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckItemInRange();

        _uiManager.IsPickupTextActive(_isItemInRange);
        ConsumableItemPickup();
    }

    void ConsumableItemPickup()
    {
        if (!_isItemInRange) return;

        Collider[] itemColliders = Physics.OverlapSphere(transform.position, _itemPickupRange * 10, _itemLayer);

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

            //if (itemObj.TryGetComponent<ConsumableItemData>(out ConsumableItemData item))
            //{
            //    if (Input.GetKeyDown(KeyCode.R))
            //    {
            //        _playerInventory.AddItem(item);
            //        Debug.Log($"{item.itemName} has been added to inventory");
            //        Destroy(itemObj);
            //    }
            //}
        }
    }

    void CheckItemInRange() => _isItemInRange = Physics.CheckSphere(transform.position, _itemPickupRange, _itemLayer);

    private void OnDrawGizmos()
    {
        Gizmos.color = _gizmoItemPickupRangeColor;
        Gizmos.DrawWireSphere(transform.position, _itemPickupRange);
    }
}
