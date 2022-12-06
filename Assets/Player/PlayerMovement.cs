using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        
        public Vector2 CurrentVelocity => _rigidbody.velocity;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        
        public void SetHorizontalVelocity(float velocity)
        {
            var newVelocity = new Vector2(velocity, CurrentVelocity.y);
            _rigidbody.velocity = newVelocity;
        }
        
        public void SetVerticalVelocity(float velocity)
        {
            var newVelocity = new Vector2(CurrentVelocity.x, velocity);
            _rigidbody.velocity = newVelocity;
        }

        /// <summary>
        /// Accelerate player horizontally in direction if not already moving at max speed
        /// </summary>
        /// <param name="horizontalInput">-1 to 1, player input direction of movement</param>
        /// <param name="acceleration">Acceleration to apply</param>
        /// <param name="maxSpeed">Max speed to move at</param>
        public void AccelerateHorizontal(float horizontalInput, float acceleration, float maxSpeed)
        {
            if (horizontalInput == 0)
                return;
            horizontalInput = Mathf.Clamp(horizontalInput, -1, 1);

            var desiredAcceleration = horizontalInput * acceleration * Time.deltaTime;

            if (Mathf.Abs(CurrentVelocity.x + desiredAcceleration) > maxSpeed)
                desiredAcceleration -= Mathf.Min(Mathf.Abs(desiredAcceleration), Mathf.Abs(CurrentVelocity.x + desiredAcceleration) - maxSpeed) * Mathf.Sign(CurrentVelocity.x);
            
            var newHorizontalVelocity = CurrentVelocity.x + desiredAcceleration;
            SetHorizontalVelocity(newHorizontalVelocity);
        }
        
        public void FrictionHorizontal(float friction)
        {
            var newHorizontalVelocity = Mathf.Max(Mathf.Abs(CurrentVelocity.x) - friction * Time.deltaTime, 0f) * Mathf.Sign(CurrentVelocity.x);
            SetHorizontalVelocity(newHorizontalVelocity);
        }
    }
}