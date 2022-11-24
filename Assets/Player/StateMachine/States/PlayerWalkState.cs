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
        }
        
        public override string ToString()
        {
            return "WALK STATE";
        }
    }
}