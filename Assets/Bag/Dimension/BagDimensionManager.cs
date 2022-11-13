using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Bag.Dimension
{
    public class BagDimensionManager : MonoBehaviour
    {
        public static BagDimensionManager Instance { get; private set; }

        [SerializeField] private GameObject cam;
        [SerializeField] private Transform entryPoint;
        [SerializeField] private Transform storedObjectsParent;
        
        public GameObject Cam => cam;
        public Transform EntryPoint => entryPoint;
        
        private struct StoredObject
        {
            public Transform transform;
            public Transform previousParent;
            public string previousScene;
        }
        
        private readonly List<StoredObject> _storedObjects = new();
        private int _storedObjectsCount;
        public UnityEvent<int> OnStoredObjectsCountChanged { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            
            OnStoredObjectsCountChanged = new UnityEvent<int>();
        }

        private void CountStoredObjects()
        {
            _storedObjectsCount = storedObjectsParent.childCount;
            OnStoredObjectsCountChanged.Invoke(_storedObjectsCount);
        }
    
        /// <summary>
        /// Stores an object in BagDimensionManager's list and updates its Transform, moving it into the dimension scene.
        /// </summary>
        /// <param name="objectTransform"></param>
        public void StoreObject(Transform objectTransform)
        {
            _storedObjects.Add(new StoredObject
            {
                transform = objectTransform,
                previousParent = objectTransform.parent,
                previousScene = objectTransform.gameObject.scene.name
            });

            objectTransform.parent = storedObjectsParent;
            CountStoredObjects();
        }
        
        /// <summary>
        /// Releases an object from the BagDimensionManager's list and restores its parent to its previous parent.
        /// If the object's previous parent was null, it switches to its previous scene.
        /// </summary>
        /// <param name="objectTransform"></param>
        public void ReleaseObject(Transform objectTransform)
        {
            var storedObject = _storedObjects.Find(x => x.transform == objectTransform);

            if (storedObject.previousParent == null)
            {
                objectTransform.parent = null;
                CustomSceneManager.MoveObjectToScene(objectTransform.gameObject, storedObject.previousScene);
            }
            else
            {
                storedObject.transform.SetParent(storedObject.previousParent);
            }
            _storedObjects.Remove(storedObject);
            CountStoredObjects();
        }
    }
}
