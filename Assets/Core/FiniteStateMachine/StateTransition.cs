using System;

namespace Core.FiniteStateMachine
{
    /// <summary>
    /// Transitions contain a target state, and a condition function to meet to switch to that state
    /// </summary>
    public class StateTransition
    {
        public State State { get; }
        public Func<bool> Condition { get; }

        public StateTransition(State state, Func<bool> condition)
        {
            State = state;
            Condition = condition;
        }
    }
}