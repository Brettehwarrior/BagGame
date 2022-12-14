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
            player.BagParentTransform.SetParent(player.OriginalParent);
            player.Bag.EnterBag(player.transform);
            player.Bag.ShowBagDimensionPreview();
            player.Bag.EnableDimensionCameraFollow();
            player.InBag = true;
        }

        public override string ToString()
        {
            return "ENTER BAG STATE";
        }
    }
}