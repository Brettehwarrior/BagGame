using System;

namespace Player.StateMachine
{
    /// <summary>
    /// Transitions contain a target state, and a condition function to meet to switch to that state
    /// </summary>
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