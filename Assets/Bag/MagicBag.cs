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

        private void Awake()
        {
            _bagShapeController = GetComponent<BagShapeController>();
            
            // Initialize Bag Dimension Scene
            CustomSceneManager.LoadScene(CustomSceneManager.SceneType.BagDimension);
        }

        private void Start()
        {
            BagDimensionManager.Instance.OnStoredObjectsCountChanged.AddListener(UpdateBagShape);
        }

        public void EnterBag(Transform objectTransform)
        {
            if (BagDimensionManager.Instance == null)
                return;
            
            var dimensionEntryPoint = BagDimensionManager.Instance.EntryPoint.position;
            objectTransform.position = new Vector3(dimensionEntryPoint.x, dimensionEntryPoint.y, objectTransform.position.z);
            BagDimensionManager.Instance.StoreObject(objectTransform);
        }

        public void ExitBag(Transform objectTransform)
        {
            if (BagDimensionManager.Instance == null)
                return;
            
            objectTransform.position = new Vector3(transform.position.x, transform.position.y, objectTransform.position.z);
            BagDimensionManager.Instance.ReleaseObject(objectTransform);
        }
        
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
