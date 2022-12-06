using UnityEngine;

namespace Player.StateMachine.States
{
    public class PlayerIdleState : PlayerState
    {
        public PlayerIdleState(Player player) : base(player)
        {
        }
        
        public override void Update()
        {
            base.Update();
            player.ApplyHorizontalFriction(player.GroundFriction);
            
            if (player.IsGrounded && player.CurrentVelocity.y <= 0f)
                player.SetGravityScale(0f);
            else
                player.SetGravityScale(player.GravityScale);
        }

        public override void ExitState()
        {
            base.ExitState();
            player.SetGravityScale(player.GravityScale);
        }

        public override string ToString()
        {
            return "IDLE STATE";
        }
    }
}