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
        
        public Transform Target => target;

        private void Update()
        {
            if (target == null)
                return;
            
            Accelerate();
            transform.position += _velocity * Time.deltaTime;
            transform.position = Vector3.SmoothDamp(transform.position, target.position, ref _velocity, smoothDamp);
        }


        private void Accelerate()
        {   
            var cachedTransform = transform;
            var direction = target.position - cachedTransform.position;
            _velocity += direction * acceleration * Time.deltaTime;
            
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