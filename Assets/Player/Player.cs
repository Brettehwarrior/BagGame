using System;
using System.Collections;
using System.Collections.Generic;
using Bag.Dimension;
using Items;
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
        private IBaggable _baggable;
        
        [SerializeField] private float walkAcceleration;
        [SerializeField] private float maxWalkSpeed;

        private void Awake()
        {
            _inputHandler = GetComponent<PlayerInputHandler>();
            _playerMovement = GetComponent<PlayerMovement>();
            _itemGrabber = GetComponent<ItemGrabber>();
            _baggable = GetComponent<IBaggable>();
        }

        private void Start()
        {
            SubscribeInputActions();
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
            if (_baggable.IsInBag())
            {
                _baggable.ExitBag();
            }
            else
            {
                _baggable.EnterBag();
            }
        }
    }
}