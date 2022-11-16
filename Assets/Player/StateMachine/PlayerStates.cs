using UnityEngine;

namespace Player.StateMachine
{
    /// <summary>
    /// Pre-made state objects to use in transitions
    /// </summary>
    public class PlayerStates
    {
        private PlayerStateMachine _stateMachine;
        private Player _player;
        
        // States
        public readonly PlayerState Idle;
        public readonly PlayerState Walk;
        
        public PlayerStates(PlayerStateMachine stateMachine, Player player)
        {
            _stateMachine = stateMachine;
            _player = player;
            
            // States
            Idle = new PlayerIdleState(_stateMachine, _player);
            Walk = new PlayerWalkState(_stateMachine, _player);
            
            CreateTransitions();
        }
        
        private void CreateTransitions()
        {
            // Idle
            Idle.AddTransition(new PlayerStateTransition(Walk, 
                () => _player.CurrentVelocity.x != 0f
                        && Mathf.Abs(_player.MovementInput.x) > 0f
                ));
            
            // Walk
            Walk.AddTransition(new PlayerStateTransition(Idle, 
                () => _player.CurrentVelocity.x == 0f
                ));
        }
    }
}