using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoorLockSystem : MonoBehaviour
{
    [Header("Locking Colors Parameter")]
    [SerializeField] Material _standbyMat;
    [SerializeField] Material _lockDeclineMat;
    [SerializeField] Material _lockAcceptMat;

    [SerializeField] float _doorCheckRadius;
    [SerializeField] LayerMask _playerLayer;
    [SerializeField] bool _isLockInRange;

    [SerializeField] KeyItemData _keyData;
    bool _isDoorActive = true;


    //bool isCheck

    Renderer _rend;
    GameObject _lockCanvas;
    GameObject _doorObj;
    UIManager _uiManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rend = GetComponent<Renderer>();
        _lockCanvas = GameObject.Find("Door Lock Canvas");
        _doorObj = transform.parent.gameObject;
        _uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
    }


    // Update is called once per frame
    void Update()
    {
        CheckLockInRange();
        //if (_isDoorActive) _lockCanvas.SetActive(_isLockInRange || false);
        HandleLockActivation();
    }

    void CheckLockInRange() => _isLockInRange = Physics.CheckSphere(transform.position, _doorCheckRadius, _playerLayer);

    void HandleLockActivation()
    {
        if (!_isLockInRange) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            bool hasKey = GameObject.Find("Player Holder").GetComponentInChildren<PlayerInventory>().HasKey(_keyData);

            if (!hasKey)
            {
                StartCoroutine(FailedCheck());
                return;
            } else
            {
                StartCoroutine(SuccessfulCheck());
            }

            

        }
    }

    IEnumerator FailedCheck()
    {
        StartCoroutine(_uiManager.DoorFailVanishText(_keyData.itemName));
        _rend.material = _lockDeclineMat;
        yield return new WaitForSeconds(0.5f);
        _rend.material = _standbyMat;
    }

    IEnumerator SuccessfulCheck()
    {
        _rend.material = _lockAcceptMat;
        StartCoroutine(_uiManager.DoorSuccessVanishText());
        yield return new WaitForSeconds(1f);
        _isDoorActive = false;
        Destroy(_doorObj);
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, _doorCheckRadius);
    }
}
