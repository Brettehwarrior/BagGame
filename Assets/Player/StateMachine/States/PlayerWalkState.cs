using System;
using UnityEngine;

namespace Player.StateMachine.States
{
    public class PlayerWalkState : PlayerState
    {
        public PlayerWalkState(Player player) : base(player)
        {
        }
        
        public override void Update()
        {
            player.DoHorizontalMovement(player.WalkAcceleration, player.MaxWalkSpeed);

            // Apply friction if input is not in direction of movement
            if (Math.Sign(player.MovementInput.x) != Math.Sign(player.CurrentVelocity.x))
            {
                player.ApplyHorizontalFriction(player.GroundFriction);
            }
        }
        
        public override string ToString()
        {
            return "WALK STATE";
        }
    }
}