using UnityEngine;

namespace Bag.Dimension
{
    public class PlayerBaggable : SimpleBaggable
    {
        [SerializeField] private Camera bagDimensionCamera;
        [SerializeField] private GameObject bagShape;
        
        private Camera _previousCamera;
        
        private void ActivateCamera()
        {
            // TODO: Get actual previous camera rather than main
            _previousCamera = Camera.main;
            
            if (_previousCamera != null)
                _previousCamera.gameObject.SetActive(false);
            
            bagDimensionCamera.gameObject.SetActive(true);
        }

        private void DeactivateCamera()
        {
            if (_previousCamera != null)
                _previousCamera.gameObject.SetActive(true);
            
            bagDimensionCamera.gameObject.SetActive(false);
        }
        
        public override void EnterBag()
        {
            base.EnterBag();
            ActivateCamera();
            bagShape.SetActive(false);
        }

        public override void ExitBag()
        {
            base.ExitBag();
            DeactivateCamera();
            bagShape.SetActive(true);
        }
    }
}