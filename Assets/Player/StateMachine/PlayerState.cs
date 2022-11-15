using System.Collections.Generic;

namespace Player.StateMachine
{
    public abstract class PlayerState
    {
        private PlayerStateMachine _stateMachine;
        private List<PlayerStateTransition> _transitions = new List<PlayerStateTransition>();
        
        public PlayerState(PlayerStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public abstract void EnterState();
        public abstract void Update();
        public abstract void FixedUpdate();
        public abstract void ExitState();
        
        public void AddTransition(PlayerStateTransition transition)
        {
            _transitions.Add(transition);
        }
        
        public void TryTransitions()
        {
            foreach (var transition in _transitions)
            {
                if (!transition.Condition())
                    continue;
                
                // Transition
                _stateMachine.ChangeState(transition.State);
                return;
            }
        }
    }
}