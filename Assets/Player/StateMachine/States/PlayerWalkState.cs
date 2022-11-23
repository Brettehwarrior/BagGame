using UnityEngine;

namespace Player.StateMachine.States
{
    public class PlayerWalkState : PlayerState
    {
        public PlayerWalkState(Player player) : base(player)
        {
        }
        
        public override void EnterState()
        {
            Debug.Log("Entering Walk State");
        }
    }
}