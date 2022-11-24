namespace Player.StateMachine.States
{
    public class PlayerJumpState : PlayerState
    {
        public PlayerJumpState(Player player) : base(player)
        {
        }

        public override void EnterState()
        {
            base.EnterState();
            player.Jump();
        }

        public override void Update()
        {
            base.Update();
            player.DoHorizontalMovement(player.AirAcceleration, player.MaxAirSpeed);
        }

        public override string ToString()
        {
            return "JUMP STATE";
        }
    }
}