using System.Collections.Generic;

namespace Core.FiniteStateMachine
{
    public abstract class State
    {
        private readonly List<StateTransition> _transitions = new List<StateTransition>();
        public virtual void EnterState() {}
        public virtual void ExitState() {}

        public void AddTransition(StateTransition transition)
        {
            _transitions.Add(transition);
        }

        /// <summary>
        /// Attempt all transitions and return the first one that succeeds, or null if all fail
        /// </summary>
        /// <returns>New state, or null if no transition is occuring</returns>
        public State TryTransitions()
        {
            foreach (var transition in _transitions)
            {
                if (!transition.Condition())
                    continue;
                
                // Transition succeeded, return the new state
                return transition.State;
            }

            return null;
        }
    }
}