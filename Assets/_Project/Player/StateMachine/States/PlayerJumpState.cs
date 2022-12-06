using System;
using UnityEngine;

namespace Player.StateMachine.States
{
    public class PlayerJumpState : PlayerState
    {
        public PlayerJumpState(Player player) : base(player)
        {
        }

        public override void EnterState()
        {
            base.EnterState();
            player.Jump();
        }

        public override void Update()
        {
            base.Update();
            player.DoHorizontalMovement(player.AirAcceleration, player.MaxAirSpeed);
            
            // Apply friction if input is not in direction of movement
            if (Math.Sign(player.MovementInput.x) != Math.Sign(player.CurrentVelocity.x))
            {
                player.ApplyHorizontalFriction(player.AirFriction);
            }
        }

        public override string ToString()
        {
            return "JUMP STATE";
        }
    }
}