using UnityEngine;

namespace Bag.Shape
{
    public class FollowPointWithOvershoot : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float acceleration = 1f;
        [SerializeField] private float smoothDamp = 1f;
        [SerializeField] private Transform center;
        [SerializeField] private AnimationCurve centerSpeedScaleCurve;
        [SerializeField] private float centerSpeedScaleCurveMaxDistance = 1f;
        
        private Vector3 _velocity;
        private Vector3 _previousPosition;
        
        public Transform Target => target;

        private void Update()
        {
            if (target == null)
                return;

            var cachedTransform = transform;
            
            cachedTransform.position = _previousPosition;
            
            Accelerate();
            cachedTransform.position += _velocity * Time.deltaTime;
            cachedTransform.position = Vector3.SmoothDamp(transform.position, target.position, ref _velocity, smoothDamp);
            
            _previousPosition = cachedTransform.position;
        }


        private void Accelerate()
        {   
            var cachedTransform = transform;
            var direction = target.position - cachedTransform.position;
            _velocity += acceleration * Time.deltaTime * direction;
            
            // Distance from center force
            if (center == null)
                return;
            
            var distanceToCenter = Vector3.Distance(transform.position, center.position);
            _velocity *= centerSpeedScaleCurve.Evaluate(distanceToCenter / centerSpeedScaleCurveMaxDistance);
        }

        private void OnDrawGizmos()
        {
            if (target != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(target.position, 0.1f);
            }
            
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, 0.1f);
        }
    }
}