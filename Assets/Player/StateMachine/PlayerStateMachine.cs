namespace Player.StateMachine
{
    public class PlayerStateMachine
    {
        public PlayerState CurrentState { get; private set; }
        
        public void ChangeState(PlayerState state)
        {
            CurrentState.EnterState();
            state.EnterState();
            CurrentState = state;
        }
    }
}