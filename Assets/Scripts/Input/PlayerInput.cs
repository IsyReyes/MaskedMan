using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5.0f;
    
    private PlayerControls _inputActions;
    private Vector2 _moveInput;
    private Animator _animator;
    
    private bool isWalking;
    
    private Vector2 _lastMoveInput;
    
    //eventt p/observer
    public static event Action IsMaskedManWalking;
public static event Action IsMaskedManStill;

    

    private void Awake()
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
            
            if (!isWalking)
            {
                IsMaskedManWalking?.Invoke();
                isWalking = true;
            }
        }
        else
        {
            _animator.SetFloat("MoveX", _lastMoveInput.x);
            _animator.SetFloat("MoveY", _lastMoveInput.y);

            
            if (isWalking)
            {
                IsMaskedManStill?.Invoke();
                isWalking = false;
            }
        }
        
        //Debug.Log("MoveX: " + _moveInput.x + " MoveY: " + _moveInput.y + " Speed: " + speed);

        
    }
    

    void Update()
    {
        Vector3 movement = new Vector3(_moveInput.x, 0, _moveInput.y) * Time.deltaTime;
        transform.Translate(movement*playerSpeed);
    }
    
}
