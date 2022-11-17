using UnityEngine;

namespace Player.StateMachine
{
    public class PlayerIdleState : PlayerState
    {
        public PlayerIdleState(Player player) : base(player)
        {
        }

        public override void EnterState()
        {
            Debug.Log("Entering Idle State");
        }
    }
}