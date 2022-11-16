using UnityEngine;

namespace Player.StateMachine
{
    public class PlayerIdleState : PlayerState
    {
        public PlayerIdleState(PlayerStateMachine stateMachine, Player player) : base(stateMachine, player)
        {
        }

        public override void EnterState()
        {
            Debug.Log("Entering Idle State");
        }
    }
}