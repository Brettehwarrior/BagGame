using System;

namespace Player.StateMachine
{
    public class PlayerStateTransition
    {
        private PlayerState _state;
        private Func<bool> _condition;
        
        public PlayerState State => _state;
        public Func<bool> Condition => _condition;
        
        public PlayerStateTransition(PlayerState state, Func<bool> condition)
        {
            _state = state;
            _condition = condition;
        }
    }
}