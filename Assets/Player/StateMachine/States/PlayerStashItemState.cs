using System;
using UnityEngine;

namespace Player.StateMachine.States
{
    public class PlayerStashItemState : PlayerState
    {
        public PlayerStashItemState(Player player) : base(player)
        {
        }

        public override void EnterState()
        {
            base.EnterState();
            player.TryStashItem();
        }

        public override string ToString()
        {
            return "STASH STATE";
        }
    }
}