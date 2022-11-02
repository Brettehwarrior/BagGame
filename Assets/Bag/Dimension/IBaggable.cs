namespace Bag.Dimension
{
    public interface IBaggable
    {
        public void EnterBag();
        public void ExitBag();
        public bool IsInBag();
    }
}