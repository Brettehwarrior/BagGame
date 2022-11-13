using UnityEngine;

namespace Bag.Shape
{
    public class StretchToPoint : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float scaleScale = 1f;

        private void Update()
        {
            if (target == null)
                return;
            
            var targetPos = new Vector3(target.position.x, target.position.y, 0f);
            var thisPos = new Vector3(transform.position.x, transform.position.y, 0f);
            
            var direction = target.position - transform.position;
            var distance = direction.magnitude;
            var scale = transform.localScale;
            scale.y = distance * scaleScale;
            transform.localScale = scale;
            transform.up = direction.normalized;
        }
    }
}