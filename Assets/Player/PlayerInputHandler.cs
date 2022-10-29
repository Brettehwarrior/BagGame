using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerInputHandler : MonoBehaviour
    {
        public Vector2 MovementInput { get; private set; }
        public UnityEvent OnPickUpItemInput { get; private set; }
        
        private PlayerInput _playerInput;
        
        // Input actions
        private InputAction _moveAction;
        private InputAction _pickUpAction;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            
            OnPickUpItemInput = new UnityEvent();
            
            _moveAction = _playerInput.actions["Move"];
            _pickUpAction = _playerInput.actions["Pick Up Item"];
        }
        
        private void Start()
        {
            _moveAction.performed += Move;
            _moveAction.canceled += Move;
         
            _pickUpAction.performed += PickUp;
        }

        private void OnDestroy()
        {
            _moveAction.performed -= Move;
            _moveAction.canceled -= Move;
            
            _pickUpAction.performed -= PickUp;
        }
        
        private void Move(InputAction.CallbackContext ctx)
        {
            var direction = ctx.ReadValue<Vector2>();
            MovementInput = direction;
        }
        
        private void PickUp(InputAction.CallbackContext ctx)
        {
            OnPickUpItemInput.Invoke();
        }
    }
}
