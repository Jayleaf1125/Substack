using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Paramters")]
    [SerializeField] private float _movementSpeed;

    [Header("Run Paramters")]
    [SerializeField] private float _runMultiplier;

    private Rigidbody _rb;
    private Vector3 _vectorMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        _vectorMovement.x = Input.GetAxisRaw("Horizontal");
        _vectorMovement.z = Input.GetAxisRaw("Vertical");

        _rb.MovePosition(_rb.position + _vectorMovement * _movementSpeed * Time.fixedDeltaTime);
    }

    private void Run()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _movementSpeed *= _runMultiplier;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _movementSpeed /= _runMultiplier;
        }
    }
}
