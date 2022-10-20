using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerInputHandler : MonoBehaviour
    {
        public Vector2 MovementInput { get; protected set; }
        
        private PlayerInput _playerInput;
        
        // Input actions
        private InputAction _moveAction;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            
            _moveAction = _playerInput.actions["Move"];
        }
        
        private void Start()
        {
            _moveAction.performed += Move;
            _moveAction.canceled += Move;
        }

        private void OnDestroy()
        {
            _moveAction.performed -= Move;
            _moveAction.canceled -= Move;
        }
        
        private void Move(InputAction.CallbackContext ctx)
        {
            var direction = ctx.ReadValue<Vector2>();
            MovementInput = direction;
        }
    }
}
