namespace Player.StateMachine.States
{
    public class PlayerExitBagState : PlayerState
    {
        public PlayerExitBagState(Player player) : base(player)
        {
        }

        public override void EnterState()
        {
            base.EnterState();
            player.ExitBag();
        }

        public override string ToString()
        {
            return "EXIT BAG STATE";
        }
    }
}