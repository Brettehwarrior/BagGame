using UnityEngine;

namespace Bag.Dimension
{
    public class SimpleBaggable : MonoBehaviour, IBaggable
    {
        [SerializeField] private Transform realWorldBagTransform;
        [SerializeField] private Transform bagDimensionEntrance;

        private bool _inBag;
        
        public virtual void EnterBag()
        {
            _inBag = true;
            transform.position = bagDimensionEntrance.position;
        }

        public virtual void ExitBag()
        {
            _inBag = false;
            transform.position = realWorldBagTransform.position;
        }

        public bool IsInBag()
        {
            return _inBag;
        }
    }
}