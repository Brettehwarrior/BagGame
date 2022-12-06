namespace Core.FiniteStateMachine
{
    /// <summary>
    /// State Machine responsible for keeping track of the current state of the player and switching between states
    /// </summary>
    public abstract class StateMachine<T> where T : State
    {
        public StateMachine(T startingState)
        {
            ChangeState(startingState);
        }

        public T CurrentState { get; private set; }

        /// <summary>
        /// Change the current state of the machine, invoking exit and enter methods
        /// </summary>
        /// <param name="state">The state to change into</param>
        public void ChangeState(State state)
        {
            CurrentState?.ExitState();
            state?.EnterState();
            CurrentState = (T) state;
        }
    }
}