namespace Player.StateMachine
{
    public class PlayerStateMachine
    {
        private Player _player;
        
        public PlayerState CurrentState { get; private set; }
        
        public PlayerStateMachine(Player player)
        {
            _player = player;
        }
        
        public void ChangeState(PlayerState state)
        {
            CurrentState.EnterState();
            state.EnterState();
            CurrentState = state;
        }
    }
}