using System.Collections.Generic;
using Player.StateMachine;

namespace FiniteStateMachine
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

        public PlayerState TryTransitions()
        {
            foreach (var transition in _transitions)
            {
                if (!transition.Condition())
                    continue;
                
                // Transition
                return transition.State;
            }

            return null;
        }
    }
}