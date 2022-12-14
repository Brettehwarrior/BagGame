using System;
using System.Collections;
using System.Collections.Generic;
using Bag.Dimension;
using Bag.Shape;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Bag
{
    public class MagicBag : MonoBehaviour
    {
        private BagShapeController _bagShapeController;
        [SerializeField] private TweenResizer tweenResizer;
        [SerializeField] private GameObject bagDimensionPrefab;
        [SerializeField] private Transform carrierTransform;
        private BagDimensionManager _bagDimensionManager;

        private void Awake()
        {
            _bagShapeController = GetComponent<BagShapeController>();
            
            // Initialize Bag Dimension
            var bagDimension = Instantiate(bagDimensionPrefab);
            _bagDimensionManager = bagDimension.GetComponent<BagDimensionManager>();
            _bagDimensionManager.SetCameraFollowTarget(carrierTransform);
        }

        private void Start()
        {
            _bagDimensionManager.OnStoredObjectsCountChanged.AddListener(UpdateBagShape);
        }
        
        public void EnableDimensionCameraFollow()
        {
            _bagDimensionManager.EnableCameraFollow();
        }
        
        public void DisableDimensionCameraFollow()
        {
            _bagDimensionManager.DisableCameraFollow();
        }
        
        /// <summary>
        /// Put another object into the bag
        /// </summary>
        /// <param name="objectTransform"></param>
        public void EnterBag(Transform objectTransform)
        {
            if (_bagDimensionManager == null)
                return;
            
            var dimensionEntryPoint = _bagDimensionManager.EntryPoint.position;
            objectTransform.position = new Vector3(dimensionEntryPoint.x, dimensionEntryPoint.y, objectTransform.position.z);
            _bagDimensionManager.StoreObject(objectTransform);
        }

        /// <summary>
        /// Take an existing object out of the bag
        /// </summary>
        /// <param name="objectTransform"></param>
        public void ExitBag(Transform objectTransform)
        {
            if (_bagDimensionManager == null)
                return;
            
            objectTransform.position = new Vector3(transform.position.x, transform.position.y, objectTransform.position.z);
            _bagDimensionManager.ReleaseObject(objectTransform);
        }
        
        /// <summary>
        /// Update the bag shape based on the number of objects stored
        /// </summary>
        /// <param name="itemCount">Number of items in bag</param>
        private void UpdateBagShape(int itemCount)
        {
            Debug.Log("Item count: " + itemCount);
            _bagShapeController.UpdateBagShapeByItemCount(itemCount);
        }
        
        public void ShowBagDimensionPreview()
        {
            tweenResizer.Grow();
        }
        
        public void HideBagDimensionPreview()
        {
            tweenResizer.Shrink();
        }
    }
}
