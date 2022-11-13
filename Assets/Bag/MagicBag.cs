using System;
using System.Collections;
using System.Collections.Generic;
using Bag.Dimension;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Bag
{
    public class MagicBag : MonoBehaviour
    {
        private void Start()
        {
            // Initialize Bag Dimension Scene
            CustomSceneManager.LoadScene(CustomSceneManager.Scenes.BagDimension);
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
    }
}
