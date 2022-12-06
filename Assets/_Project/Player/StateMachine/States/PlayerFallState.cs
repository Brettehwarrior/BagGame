using System;
using UnityEngine;

namespace Player.StateMachine.States
{
    public class PlayerFallState : PlayerState
    {
        public PlayerFallState(Player player) : base(player)
        {
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
            return "FALL STATE";
        }
    }
}