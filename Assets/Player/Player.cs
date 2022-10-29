using System;
using System.Collections;
using System.Collections.Generic;
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
        
        [SerializeField] private float walkAcceleration;
        [SerializeField] private float maxWalkSpeed;

        private void Awake()
        {
            _inputHandler = GetComponent<PlayerInputHandler>();
            _playerMovement = GetComponent<PlayerMovement>();
            _itemGrabber = GetComponent<ItemGrabber>();
        }

        private void Start()
        {
            SubscribeInputActions();
        }

        private void SubscribeInputActions()
        {
            _inputHandler.OnPickUpItemInput.AddListener(_itemGrabber.TryPickUpItem);
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
            _itemGrabber.TryPickUpItem();
        }
    }
}