namespace Player.StateMachine.States
{
    public class PlayerFallState : PlayerState
    {
        public PlayerFallState(Player player) : base(player)
        {
        }
        
        public override string ToString()
        {
            return "FALL STATE";
        }
    }
}