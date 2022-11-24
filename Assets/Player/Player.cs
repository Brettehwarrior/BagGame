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
        [SerializeField] private float walkAcceleration;
        [SerializeField] private float maxWalkSpeed;
        [SerializeField] private float jumpSpeed;
        [SerializeField] private float landingHorizontalSpeedMultiplier;

        // Status
        public Vector2 CurrentVelocity => _playerMovement.CurrentVelocity;
        public bool IsGrounded => _sideChecker.Bottom;
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

        public void DoHorizontalMovement()
        {
            _playerMovement.AccelerateHorizontal(_inputHandler.MovementInput.x, walkAcceleration, maxWalkSpeed);
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
    }
}