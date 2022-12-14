using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Bag.Dimension
{
    public class BagDimensionManager : MonoBehaviour
    {
        [SerializeField] private Transform entryPoint;
        [SerializeField] private Transform storedObjectsParent;
        [SerializeField] private BoundedFollow boundedFollow;

        private int _storedObjectsCount;
        public UnityEvent<int> OnStoredObjectsCountChanged { get; private set; }
        public Transform EntryPoint => entryPoint;

        private void Awake()
        {
            OnStoredObjectsCountChanged = new UnityEvent<int>();
        }

        private void CountStoredObjects()
        {
            _storedObjectsCount = storedObjectsParent.childCount;
            OnStoredObjectsCountChanged.Invoke(_storedObjectsCount);
        }
    
        /// <summary>
        /// Stores an object in BagDimensionManager's list and updates its Transform, moving it into the dimension.
        /// </summary>
        /// <param name="objectTransform"></param>
        public void StoreObject(Transform objectTransform)
        {
            objectTransform.position = entryPoint.position;
            objectTransform.parent = storedObjectsParent;
            CountStoredObjects();
        }
        
        /// <summary>
        /// Releases an object from the BagDimensionManager's list and restores its parent to the
        /// main scene parent set by first object stored.
        /// </summary>
        /// <param name="objectTransform"></param>
        public void ReleaseObject(Transform objectTransform)
        {
            objectTransform.transform.SetParent(null);
            CountStoredObjects();
        }

        public void SetCameraFollowTarget(Transform target)
        {
            boundedFollow.Target = target;
        }
        
        public void EnableCameraFollow()
        {
            boundedFollow.enabled = true;
        }
        
        public void DisableCameraFollow()
        {
            boundedFollow.enabled = false;
        }
    }
}
