using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public float playerSpeed = 5.0f;
    
    private PlayerControls _inputActions;
    private Vector2 _moveInput;
    private Animator _animator;
    
    private Vector2 _lastMoveInput;

    void Awake()
    {
        _inputActions = new PlayerControls();
        _animator = GetComponent<Animator>();
        
    }

    private void OnEnable()
    {
        _inputActions.Movement.Enable();

        _inputActions.Movement.Movement.performed += OnMovePerformed;
        _inputActions.Movement.Movement.canceled += OnMoveCanceled;
    }
    
    private void OnDisable()
    {
        _inputActions.Movement.Disable();

        _inputActions.Movement.Movement.performed -= OnMovePerformed;
        _inputActions.Movement.Movement.canceled -= OnMoveCanceled;
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
        
        if (_moveInput != Vector2.zero)
        {
            _lastMoveInput = _moveInput;
        }
        
        UpdateAnimator();
    }
    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        _moveInput = Vector2.zero;
        UpdateAnimator();
    }
    
    private void UpdateAnimator()
    {
        float speed = _moveInput.magnitude;
        _animator.SetFloat("Speed", speed);
        
        if (speed > 0)
        {
            _animator.SetFloat("MoveX", _moveInput.x);
            _animator.SetFloat("MoveY", _moveInput.y);
        }
        else
        {
            // If speed is 0, reset MoveX and MoveY to 0 for idle animations
            _animator.SetFloat("MoveX", _lastMoveInput.x);
            _animator.SetFloat("MoveY", _lastMoveInput.y);

            // You can optionally use _lastDirection for visual purposes, but avoid overriding blend parameters with it
        }
        
        Debug.Log("MoveX: " + _moveInput.x + " MoveY: " + _moveInput.y + " Speed: " + speed);

        
    }
    

    void Update()
    {
        Vector3 movement = new Vector3(_moveInput.x, 0, _moveInput.y) * Time.deltaTime;
        transform.Translate(movement*playerSpeed);
    }
    
}
