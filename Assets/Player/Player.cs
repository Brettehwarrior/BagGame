using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerInputHandler))]
    [RequireComponent(typeof(PlayerMovement))]
    public class Player : MonoBehaviour
    {
        private PlayerInputHandler _inputHandler;
        private PlayerMovement _playerMovement;
        
        [SerializeField] private float walkAcceleration;
        [SerializeField] private float maxWalkSpeed;

        private void Awake()
        {
            _inputHandler = GetComponent<PlayerInputHandler>();
            _playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            DoMovement();
        }

        private void DoMovement()
        {
            _playerMovement.AccelerateHorizontal(_inputHandler.MovementInput.x, walkAcceleration, maxWalkSpeed);
            // _playerMovement.SetHorizontalVelocity(_playerMovement.CurrentVelocity.x +
            //                                       (_inputHandler.MovementInput.x * walkAcceleration * Time.deltaTime));
        }
    }
}