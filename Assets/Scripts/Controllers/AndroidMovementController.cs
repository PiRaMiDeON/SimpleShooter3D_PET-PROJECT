using UnityEngine;

public class AndroidMovementController : MonoBehaviour
{
    private CharacterController _characterController;

    [Header("Moving settings")]
    [Range(0, 100)]
    [SerializeField] private float _movementSpeed;
    [Range(0, 100)]
    [SerializeField] private float _jumpForce;

    private float _gravity = -9.8f;
    private Vector3 _velocity;

    [Header("Ground check settings")]
    [SerializeField] private Transform _checkTransform;
    [Range(0, 10)]
    [SerializeField] private float _checkRadius;
    [SerializeField] private LayerMask _groundLayer;

    [Header("Android Features")]
    [SerializeField] private FixedJoystick _fixedJoystick;
    [SerializeField] private GameObject _AndroidUI;

    private bool _isGrounded;
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();

        if (!_AndroidUI.activeInHierarchy)
        {
            _AndroidUI.SetActive(true);
        }
    }
    private void Update()
    {
        _isGrounded = Physics.CheckSphere(_checkTransform.position, _checkRadius, _groundLayer);

        Move();
    }

    public void Move()
    {
        float xMove = _fixedJoystick.Horizontal;
        float zMove = _fixedJoystick.Vertical;

        Vector3 moveDirection = transform.right * xMove + transform.forward * zMove;

        _characterController.Move(moveDirection * _movementSpeed * Time.deltaTime);

        _velocity.y += _gravity * Time.deltaTime;

        _characterController.Move(_velocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (_isGrounded)
        {
            _velocity.y = Mathf.Sqrt(_jumpForce);
        }
    }
}
