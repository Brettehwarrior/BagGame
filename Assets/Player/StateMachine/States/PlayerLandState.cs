namespace Player.StateMachine.States
{
    public class PlayerLandState : PlayerState
    {
        public PlayerLandState(Player player) : base(player)
        {
        }

        public override void EnterState()
        {
            base.EnterState();
            player.MultiplyHorizontalSpeed(player.LandingHorizontalSpeedMultiplier);
        }

        public override string ToString()
        {
            return "LAND STATE";
        }
    }
}