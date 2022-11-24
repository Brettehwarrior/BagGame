﻿namespace Player.StateMachine.States
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
        }
        
        public override string ToString()
        {
            return "FALL STATE";
        }
    }
}