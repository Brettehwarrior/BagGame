using System.Collections.Generic;

namespace Player.StateMachine
{
    public abstract class PlayerState
    {
        private readonly PlayerStateMachine _stateMachine;
        private readonly List<PlayerStateTransition> _transitions = new List<PlayerStateTransition>();
        
        protected readonly Player player;
        
        public PlayerState(PlayerStateMachine stateMachine, Player player)
        {
            _stateMachine = stateMachine;
            this.player = player;
        }
        
        public virtual void EnterState() {}
        public virtual void Update() {}
        public virtual void FixedUpdate() {}
        public virtual void ExitState() {}
        
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