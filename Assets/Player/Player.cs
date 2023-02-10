using System;
using System.Collections;
using System.Collections.Generic;
using Bag;
using Bag.Dimension;
using Items;
using Player.StateMachine;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerInputHandler))]
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(RaycastSideChecker))]
    public class Player : MonoBehaviour
    {
        private PlayerInputHandler _inputHandler;
        private PlayerMovement _playerMovement;
        private ItemGrabber _itemGrabber;
        private RaycastSideChecker _sideChecker;

        private PlayerStateMachine _stateMachine;
     
        // Properties
        [Header("Bag properties")]
        [SerializeField] private MagicBag bag;
        public MagicBag Bag => bag;
        [SerializeField] private Transform bagParentTransform;
        public Transform BagParentTransform => bagParentTransform;
        public Transform OriginalParent { get; private set; }
        
        [Header("Movement Values")]
        
        [Tooltip("Acceleration while on ground")]
        [SerializeField]
        private float walkAcceleration;
        public float WalkAcceleration => walkAcceleration;
        
        [Tooltip("Maximum horizontal speed while on ground")]
        [SerializeField]
        private float maxWalkSpeed;
        public float MaxWalkSpeed => maxWalkSpeed;
        
        [Tooltip("Friction while on ground")]
        [SerializeField]
        private float groundFriction;
        public float GroundFriction => groundFriction;
        
        [Tooltip("Acceleration while in air")]
        [SerializeField]
        private float airAcceleration;
        public float AirAcceleration => airAcceleration;
        
        [Tooltip("Maximum horizontal speed while in air")]
        [SerializeField]
        private float maxAirSpeed;
        public float MaxAirSpeed => maxAirSpeed;
        
        [Tooltip("Friction while in air")]
        [SerializeField]
        private float airFriction;
        public float AirFriction => airFriction;
        
        [Tooltip("Instantaneous vertical speed when jumping")]
        [SerializeField]
        private float jumpSpeed;
        public float JumpSpeed => jumpSpeed;
        
        [Tooltip("Default Gravity Scale")]
        [SerializeField]
        private float gravityScale = 1f;
        public float GravityScale => gravityScale;
        
        [Tooltip("Multiplier for current horizontal velocity when landing without input")]
        [SerializeField]
        private float landingHorizontalSpeedMultiplier;
        public float LandingHorizontalSpeedMultiplier => landingHorizontalSpeedMultiplier;

        // Status
        public bool InBag { get; set; }
        public IItem heldItem => _itemGrabber._heldItem;
        public Vector2 CurrentVelocity => _playerMovement.CurrentVelocity;
        public bool IsGrounded => _sideChecker.Bottom;
        public bool IsCollidingLeft => _sideChecker.Left;
        public bool IsCollidingRight => _sideChecker.Right;
        public Vector2 MovementInput => _inputHandler.MovementInput;
        public bool EnterExitBagInputDown => _inputHandler.EnterExitBagInputDown;
        public bool JumpInputDown => _inputHandler.JumpInputDown;
        
        private void Awake()
        {
            _inputHandler = GetComponent<PlayerInputHandler>();
            _playerMovement = GetComponent<PlayerMovement>();
            _itemGrabber = GetComponent<ItemGrabber>();
            _sideChecker = GetComponent<RaycastSideChecker>();
        }

        private void Start()
        {
            SubscribeInputActions();
            InitializeStateMachine();
            OriginalParent = transform.parent;
        }

        private void InitializeStateMachine()
        {
            var states = new PlayerStates(this);
            _stateMachine = new PlayerStateMachine(states.StartState);
        }

        private void SubscribeInputActions()
        {
            _inputHandler.OnPickUpItemInput.AddListener(TryPickUpItem); // TODO: This gets fired once on play (because left click starts game maybe?)
            _inputHandler.OnStashItemInput.AddListener(TryStashItem);
        }

        private void Update()
        {
            _stateMachine.Update();
        }

        private void FixedUpdate()
        {
            _stateMachine.FixedUpdate();
        }

        private void LateUpdate()
        {
            _stateMachine.LateUpdate();
        }

        public void DoHorizontalMovement(float acceleration, float maxSpeed)
        {
            _playerMovement.AccelerateHorizontal(_inputHandler.MovementInput.x, acceleration, maxSpeed);
        }
        
        private void TryPickUpItem()
        {
            _itemGrabber.TryPickUpDropItem();
        }

        private void TryStashItem()
        {
            Debug.Log("stashed Item");
            Transform test = _itemGrabber.HeldItemStash();
            bag.EnterBag(test);
        }
        
        public void Jump()
        {
            _playerMovement.SetVerticalVelocity(jumpSpeed);
        }
        
        public void MultiplyHorizontalSpeed(float multiplier)
        {
            _playerMovement.SetHorizontalVelocity(CurrentVelocity.x * multiplier);
        }
        
        public void ApplyHorizontalFriction(float friction)
        {
            _playerMovement.FrictionHorizontal(friction);
        }
        
        public void SetGravityScale(float gravityScale)
        {
            _playerMovement.SetGravityScale(gravityScale);
        }
    }
}