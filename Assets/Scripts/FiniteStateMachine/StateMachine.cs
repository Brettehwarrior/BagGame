namespace FiniteStateMachine
{
    public class StateMachine<T> where T : State
    {
        public StateMachine(T startingState)
        {
            ChangeState(startingState);
        }

        public T CurrentState { get; private set; }

        /// <summary>
        /// Change the current state of the player, invoking exit and enter methods
        /// </summary>
        /// <param name="state"></param>
        protected void ChangeState(T state)
        {
            CurrentState?.ExitState();
            state?.EnterState();
            CurrentState = state;
        }
    }
}