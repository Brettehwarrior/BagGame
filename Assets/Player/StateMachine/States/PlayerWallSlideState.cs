namespace Player.StateMachine.States
{
    public class PlayerWallSlideState : PlayerState
    {
        public PlayerWallSlideState(Player player) : base(player)
        {
        }

        public override void Update()
        {
            base.Update();
            player.DoHorizontalMovement(player.AirAcceleration, player.MaxAirSpeed);
        }

        public override string ToString()
        {
            return "WALL SLIDE STATE";
        }
    }
}