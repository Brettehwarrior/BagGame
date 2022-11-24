using System;
using System.Collections;
using System.Collections.Generic;
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
        private PlayerBagUser _bagUser;
        private RaycastSideChecker _sideChecker;

        private PlayerStateMachine _stateMachine;
     
        // Properties
        [Header("Movement Values")]
        [SerializeField] private float walkAcceleration;
        public float WalkAcceleration => walkAcceleration;
        [SerializeField] private float maxWalkSpeed;
        public float MaxWalkSpeed => maxWalkSpeed;
        [SerializeField] private float airAcceleration;
        public float AirAcceleration => airAcceleration;
        [SerializeField] private float maxAirSpeed;
        public float MaxAirSpeed => maxAirSpeed;
        [SerializeField] private float jumpSpeed;
        public float JumpSpeed => jumpSpeed;
        [SerializeField] private float landingHorizontalSpeedMultiplier;
        public float LandingHorizontalSpeedMultiplier => landingHorizontalSpeedMultiplier;

        // Status
        public Vector2 CurrentVelocity => _playerMovement.CurrentVelocity;
        public bool IsGrounded => _sideChecker.Bottom;
        public bool IsCollidingLeft => _sideChecker.Left;
        public bool IsCollidingRight => _sideChecker.Right;
        public Vector2 MovementInput => _inputHandler.MovementInput;
        public bool JumpInputDown => _inputHandler.JumpInputDown;
        
        private void Awake()
        {
            _inputHandler = GetComponent<PlayerInputHandler>();
            _playerMovement = GetComponent<PlayerMovement>();
            _itemGrabber = GetComponent<ItemGrabber>();
            _bagUser = GetComponent<PlayerBagUser>();
            _sideChecker = GetComponent<RaycastSideChecker>();
        }

        private void Start()
        {
            SubscribeInputActions();
            InitializeStateMachine();
        }

        private void InitializeStateMachine()
        {
            var states = new PlayerStates(this);
            _stateMachine = new PlayerStateMachine(states.StartState);
        }

        private void SubscribeInputActions()
        {
            _inputHandler.OnPickUpItemInput.AddListener(TryPickUpItem); // TODO: This gets fired once on play (because left click starts game maybe?)
            _inputHandler.OnEnterExitBagInput.AddListener(EnterExitBag);
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

        private void EnterExitBag()
        {
            if (_bagUser.InBag)
            {
                _bagUser.ExitBag();
            }
            else
            {
                _bagUser.EnterBag();
            }
        }

        public void Jump()
        {
            _playerMovement.SetVerticalVelocity(jumpSpeed);
        }
        
        public void MultiplyHorizontalSpeed(float multiplier)
        {
            _playerMovement.SetHorizontalVelocity(CurrentVelocity.x * multiplier);
        }
    }
}