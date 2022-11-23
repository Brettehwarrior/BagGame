using FiniteStateMachine;
using Player.StateMachine.States;
using UnityEngine;

namespace Player.StateMachine
{
    /// <summary>
    /// Pre-made state objects to use in transitions (is this a factory? idk)
    /// </summary>
    public class PlayerStates
    {
        private readonly Player _player;
        
        // States
        private readonly PlayerState _idleState;
        private readonly PlayerState _walkState;
        private readonly PlayerState _jumpState;
        
        // Entry state
        public PlayerState StartState => _idleState;
        
        public PlayerStates(Player player)
        {
            _player = player;
            
            // States
            _idleState = new PlayerIdleState(_player);
            _walkState = new PlayerWalkState(_player);
            
            CreateTransitions();
        }
        
        private void CreateTransitions()
        {
            // var jumpTransition = new StateTransition();
            
            // Idle
            _idleState.AddTransition(new StateTransition(_walkState, 
                () => _player.CurrentVelocity.x != 0f
                        && Mathf.Abs(_player.MovementInput.x) > 0f
                ));
            
            // Walk
            _walkState.AddTransition(new StateTransition(_idleState, 
                () => _player.CurrentVelocity.x == 0f
                ));
        }
    }
}