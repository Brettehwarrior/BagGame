namespace Player.StateMachine.States
{
    public class PlayerEnterBagState : PlayerState
    {
        public PlayerEnterBagState(Player player) : base(player)
        {
        }

        public override void EnterState()
        {
            base.EnterState();
            player.EnterBag();
        }

        public override string ToString()
        {
            return "ENTER BAG STATE";
        }
    }
}