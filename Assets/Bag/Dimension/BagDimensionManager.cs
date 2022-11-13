using UnityEngine;

namespace Bag.Dimension
{
    public class BagDimensionManager : MonoBehaviour
    {
        public static BagDimensionManager Instance { get; private set; }

        [SerializeField] private GameObject cam;
        [SerializeField] private Transform entryPoint;
        
        public GameObject Cam => cam;
        public Transform EntryPoint => entryPoint;
    
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
        }
    
        
    }
}
