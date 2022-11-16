using UnityEngine;

namespace Player.StateMachine
{
    public class PlayerWalkState : PlayerState
    {
        public PlayerWalkState(PlayerStateMachine stateMachine, Player player) : base(stateMachine, player)
        {
        }
        
        public override void EnterState()
        {
            Debug.Log("Entering Walk State");
        }
    }
}