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
    public class Player : MonoBehaviour
    {
        private PlayerInputHandler _inputHandler;
        private PlayerMovement _playerMovement;
        private ItemGrabber _itemGrabber;
        private PlayerBagUser _bagUser;

        private PlayerStateMachine _stateMachine;
        private PlayerStates _states;
     
        // Properties
        [SerializeField] private float walkAcceleration;
        [SerializeField] private float maxWalkSpeed;

        // Status
        public Vector2 CurrentVelocity => _playerMovement.CurrentVelocity;
        public Vector2 MovementInput => _inputHandler.MovementInput;
        
        private void Awake()
        {
            _inputHandler = GetComponent<PlayerInputHandler>();
            _playerMovement = GetComponent<PlayerMovement>();
            _itemGrabber = GetComponent<ItemGrabber>();
            _bagUser = GetComponent<PlayerBagUser>();
        }

        private void Start()
        {
            SubscribeInputActions();
            InitializeStateMachine();
        }

        private void InitializeStateMachine()
        {
            _states = new PlayerStates(this);
            _stateMachine = new PlayerStateMachine(_states.StartState);
        }

        private void SubscribeInputActions()
        {
            // TODO: This gets fired once on play (because left click starts game maybe?)
            _inputHandler.OnPickUpItemInput.AddListener(TryPickUpItem);
            _inputHandler.OnEnterExitBagInput.AddListener(EnterExitBag);
        }

        private void Update()
        {
            DoMovement();
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

        private void DoMovement()
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
    }
}