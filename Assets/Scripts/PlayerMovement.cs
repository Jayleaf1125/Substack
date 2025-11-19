using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] private float _movementSpeed;

    [Header("Run Parameters")]
    [SerializeField] private float _sprintSpeedMultiplier;

    [Header("Jump Parameters")]
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _jumpRayDistance;
    private bool _isGrounded = true;

    [Header("Gizmos Parameters")]
    [SerializeField] private bool _isGizmosOn;




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
        CheckIfPlayerIsGrounded();
        Run();
        Jump();
    }

    void FixedUpdate()
    {
        Movement();
    }

    void CheckIfPlayerIsGrounded()
    {
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, _jumpRayDistance, _groundLayer);
    }


    void Jump()
    {
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _rb.AddForce(new Vector3(0, _jumpForce, 0), ForceMode.Impulse);
            _isGrounded = false;
        }
    }

    private void Movement()
    {
        _vectorMovement.x = Input.GetAxisRaw("Horizontal");
        _vectorMovement.z = Input.GetAxisRaw("Vertical");

        _rb.MovePosition(_rb.position + _vectorMovement * _movementSpeed * Time.fixedDeltaTime);
    }

    private void Run()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _movementSpeed *= _sprintSpeedMultiplier;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _movementSpeed /= _sprintSpeedMultiplier;
        }
    }

    private void OnDrawGizmos()
    {
        if (_isGizmosOn)
        {

        }
    }
}
