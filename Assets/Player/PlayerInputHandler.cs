using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInputHandler : MonoBehaviour
    {
        [SerializeField] private InputActionReference moveActionReference;
        [SerializeField] private InputActionReference pickUpActionReference;
        [SerializeField] private InputActionReference enterExitBagActionReference;
        [SerializeField] private InputActionReference jumpActionReference;
        [SerializeField] private InputActionReference stashActionReference;
        
        public Vector2 MovementInput { get; private set; }
        public UnityEvent OnPickUpItemInput { get; private set; }
        public bool StashItemInputDown { get; private set; }
        public bool EnterExitBagInputDown { get; private set; }
        public bool JumpInputDown { get; private set; }
        
        private void Awake()
        {
            OnPickUpItemInput = new UnityEvent();
        }

        private void OnEnable()
        {
            moveActionReference.action.Enable();
            pickUpActionReference.action.Enable();
            enterExitBagActionReference.action.Enable();
            jumpActionReference.action.Enable();
            stashActionReference.action.Enable();
        }
        
        private void OnDisable()
        {
            moveActionReference.action.Disable();
            pickUpActionReference.action.Disable();
            enterExitBagActionReference.action.Disable();
            jumpActionReference.action.Disable();
            stashActionReference.action.Disable();
        }

        private void Start()
        {
            moveActionReference.action.performed += Move;
            moveActionReference.action.canceled += Move;
         
            pickUpActionReference.action.performed += PickUp;
        }

        private void OnDestroy()
        {
            moveActionReference.action.performed -= Move;
            moveActionReference.action.canceled -= Move;
            
            pickUpActionReference.action.performed -= PickUp;
        }

        private void Update()
        {
            EnterExitBagInputDown = enterExitBagActionReference.action.WasPerformedThisFrame();
            JumpInputDown = jumpActionReference.action.WasPerformedThisFrame();
            StashItemInputDown = stashActionReference.action.WasPerformedThisFrame();
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
