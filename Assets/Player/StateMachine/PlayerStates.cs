using FiniteStateMachine;
using UnityEngine;

namespace Player.StateMachine
{
    /// <summary>
    /// Pre-made state objects to use in transitions
    /// </summary>
    public class PlayerStates
    {
        private readonly Player _player;
        
        // States
        private readonly PlayerState _idle;
        private readonly PlayerState _walk;
        
        // Entry state
        public PlayerState StartState => _idle;
        
        public PlayerStates(Player player)
        {
            _player = player;
            
            // States
            _idle = new PlayerIdleState(_player);
            _walk = new PlayerWalkState(_player);
            
            CreateTransitions();
        }
        
        private void CreateTransitions()
        {
            // Idle
            _idle.AddTransition(new StateTransition(_walk, 
                () => _player.CurrentVelocity.x != 0f
                        && Mathf.Abs(_player.MovementInput.x) > 0f
                ));
            
            // Walk
            _walk.AddTransition(new StateTransition(_idle, 
                () => _player.CurrentVelocity.x == 0f
                ));
        }
    }
}