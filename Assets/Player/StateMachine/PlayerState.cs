using System.Collections.Generic;
using FiniteStateMachine;

namespace Player.StateMachine
{
    /// <summary>
    /// A state object used in a state machine
    /// Defines state behaviour for various methods
    /// </summary>
    public abstract class PlayerState : State
    {
        protected readonly Player player;
        
        public PlayerState(Player player)
        {
            this.player = player;
        }

        public virtual void Update() {}
        public virtual void FixedUpdate() {}
        public virtual void LateUpdate() {}
    }
}