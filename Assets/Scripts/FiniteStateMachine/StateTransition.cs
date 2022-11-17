using System;
using Player.StateMachine;

namespace FiniteStateMachine
{
    /// <summary>
    /// Transitions contain a target state, and a condition function to meet to switch to that state
    /// </summary>
    public class StateTransition
    {
        private PlayerState _state;
        private Func<bool> _condition;
        
        public PlayerState State => _state;
        public Func<bool> Condition => _condition;
        
        public StateTransition(PlayerState state, Func<bool> condition)
        {
            _state = state;
            _condition = condition;
        }
    }
}