using Core.FiniteStateMachine;
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
        private readonly PlayerState _fallState;
        private readonly PlayerState _landState;
        private readonly PlayerState _wallSlideState;
        private readonly PlayerState _enterBagState;
        private readonly PlayerState _exitBagState;
        
        // Entry state
        public PlayerState StartState => _idleState;
        
        public PlayerStates(Player player)
        {
            _player = player;
            
            // States
            _idleState = new PlayerIdleState(_player);
            _walkState = new PlayerWalkState(_player);
            _jumpState = new PlayerJumpState(_player);
            _fallState = new PlayerFallState(_player);
            _landState = new PlayerLandState(_player);
            _wallSlideState = new PlayerWallSlideState(_player);
            _enterBagState = new PlayerEnterBagState(_player);
            _exitBagState = new PlayerExitBagState(_player);
            
            CreateTransitions();
        }
        
        private void CreateTransitions()
        {
            // Transitions to jump state
            var jumpTransition = new StateTransition(_jumpState, () => _player.JumpInputDown);
            _idleState.AddTransition(jumpTransition);
            _walkState.AddTransition(jumpTransition);
            
            // Transitions to fall state
            var fallTransition = new StateTransition(_fallState, () => _player.CurrentVelocity.y < 0);
            _jumpState.AddTransition(fallTransition);
            _idleState.AddTransition(fallTransition);
            _walkState.AddTransition(fallTransition);
            _wallSlideState.AddTransition(new StateTransition(_fallState, () =>
                !(_player.IsCollidingLeft || _player.IsCollidingRight)));
            
            // Transitions to walk state
            _idleState.AddTransition(new StateTransition(_walkState, () =>
                Mathf.Abs(_player.MovementInput.x) > 0f));
            
            // Transitions to idle state
            _walkState.AddTransition(new StateTransition(_idleState, () =>
                _player.CurrentVelocity.x == 0f));
            // TODO: These transitions are instantaneous, need animation
            _landState.AddTransition(new StateTransition(_idleState, () => true)); // Landing state animation will probably be cancellable
            _enterBagState.AddTransition(new StateTransition(_idleState, () => true));
            _exitBagState.AddTransition(new StateTransition(_idleState, () => true));
            
            // Transitions to land state
            var landTransition = new StateTransition(_landState, () => _player.IsGrounded);
            _fallState.AddTransition(landTransition);
            _wallSlideState.AddTransition(landTransition);
            
            // Transitions to wall slide state
            var wallSlideTransition = new StateTransition(_wallSlideState, () =>
                _player.IsCollidingLeft || _player.IsCollidingRight);
            _jumpState.AddTransition(wallSlideTransition);
            _fallState.AddTransition(wallSlideTransition);
            
            // Transitions to enter bag state
            var enterBagTransition = new StateTransition(_enterBagState, () =>
                _player.EnterExitBagInputDown && !_player.InBag);
            _idleState.AddTransition(enterBagTransition);
            _walkState.AddTransition(enterBagTransition);
            _jumpState.AddTransition(enterBagTransition);
            _fallState.AddTransition(enterBagTransition);
            _landState.AddTransition(enterBagTransition);
            _wallSlideState.AddTransition(enterBagTransition);
            
            // Transitions to exit bag state
            var exitBagTransition = new StateTransition(_exitBagState, () =>
                _player.EnterExitBagInputDown && _player.InBag);
            _idleState.AddTransition(exitBagTransition);
            _walkState.AddTransition(exitBagTransition);
            _jumpState.AddTransition(exitBagTransition);
            _fallState.AddTransition(exitBagTransition);
            _landState.AddTransition(exitBagTransition);
            _wallSlideState.AddTransition(exitBagTransition);
        }
    }
}