namespace Player.StateMachine
{
    /// <summary>
    /// State Machine responsible for keeping track of the current state of the player and switching between states
    /// </summary>
    public class PlayerStateMachine
    {
        private Player _player;
        public PlayerState CurrentState { get; private set; }
        
        // Constructor
        public PlayerStateMachine(Player player)
        {
            _player = player;
        }

        /// <summary>
        /// Change the current state of the player, invoking exit and enter methods
        /// </summary>
        /// <param name="state"></param>
        public void ChangeState(PlayerState state)
        {
            CurrentState?.ExitState();
            state?.EnterState();
            CurrentState = state;
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
            CurrentState?.TryTransitions();
        }
    }
}