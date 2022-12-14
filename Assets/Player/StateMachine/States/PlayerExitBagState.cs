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
            player.Bag.DisableDimensionCameraFollow();
            player.Bag.ExitBag(player.transform);
            player.BagParentTransform.SetParent(player.transform);
            player.Bag.HideBagDimensionPreview();
            player.InBag = false;
        }

        public override string ToString()
        {
            return "EXIT BAG STATE";
        }
    }
}