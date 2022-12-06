using Bag;
using Bag.Dimension;
using UnityEngine;

namespace Player
{
    public class PlayerBagUser : MonoBehaviour
    {
        [SerializeField] private MagicBag bag;
        [SerializeField] private Transform bagTransform;
        [SerializeField] private Transform bagParent;

        private void Start()
        {
            BagDimensionManager.Instance.SetCameraFollowTarget(transform);
        }

        public bool InBag { get; private set; }
        public void EnterBag()
        {
            // Detach bag
            bagParent.SetParent(transform.parent, true);
        
            InBag = true;
            bag.EnterBag(transform);
        
            bag.ShowBagDimensionPreview();
            BagDimensionManager.Instance.EnableCameraFollow();
        }
    
        public void ExitBag()
        {
            BagDimensionManager.Instance.DisableCameraFollow();
            InBag = false;
            bag.ExitBag(transform);
        
            // Attach bag
            bagParent.SetParent(transform, true);
        
            bag.HideBagDimensionPreview();
        }
    }
}
