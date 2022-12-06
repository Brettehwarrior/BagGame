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
        }

        public override string ToString()
        {
            return "IDLE STATE";
        }
    }
}