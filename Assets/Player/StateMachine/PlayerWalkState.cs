using UnityEngine;

namespace Player.StateMachine
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