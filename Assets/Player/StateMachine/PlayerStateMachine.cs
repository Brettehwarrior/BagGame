using FiniteStateMachine;

namespace Player.StateMachine
{
    public class PlayerStateMachine : StateMachine<PlayerState>
    {
        // Constructor
        public PlayerStateMachine(PlayerState startingState) : base(startingState)
        {
        }

        public void Update()
        {
            CurrentState?.Update();
        }
        
        public void FixedUpdate()
        {
            CurrentState?.FixedUpdate();
        }
        
        public void LateUpdate()
        {
            CurrentState?.LateUpdate();
            
            // Check state transitions, and change state if one succeeds
            var nextState = CurrentState?.TryTransitions();
            if (nextState != null)
                ChangeState(nextState);
        }
    }
}