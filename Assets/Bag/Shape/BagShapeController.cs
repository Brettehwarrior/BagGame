using System.Collections.Generic;
using UnityEngine;

namespace Bag.Shape
{
    public class BagShapeController : MonoBehaviour
    {
        [SerializeField] private SplinePositionSetter splinePositionSetter;
        [SerializeField] private Transform targetPointParent;
        
        [Header("Shape Properties")]
        [SerializeField] private float minScale = 1f;
        [SerializeField] private float maxScale = 5f;
        [SerializeField] [Range(0f, 1f)] private float scalePercentage = 1f;
        [SerializeField] [Range(-1f, 1f)] private float xOffset = 0f;
        [SerializeField] private float xOffsetScale = 1f;
        
        [Header("Scale Control")]
        [SerializeField] private AnimationCurve scaleCurve;
        [SerializeField] private int itemsToMaxScale = 10;

        private void Update()
        {
            if (targetPointParent == null)
                return;
            
            ScaleTargetPoints();
            OffsetTargetPoints();
        }

        private void ScaleTargetPoints()
        {
            var scale = minScale + (maxScale-minScale) * scalePercentage;
            targetPointParent.localScale = Vector3.one * scale;
            splinePositionSetter.TangentScale = scale / maxScale;
        }
        
        private void OffsetTargetPoints()
        {
            var pos = targetPointParent.localPosition;
            targetPointParent.localPosition = new Vector3(xOffset * xOffsetScale, pos.y, pos.z);
        }

        public void SnapToTargets()
        {
            foreach (var point in splinePositionSetter.Points)
            {
                var target = point.GetComponent<FollowPointWithOvershoot>().Target;
                point.position = target.position;
            }
            
            splinePositionSetter.UpdateSpline();
        }

        public void SetTargets(Transform parent)
        {
            targetPointParent = parent;
            splinePositionSetter.Points = parent.GetComponentsInChildren<Transform>();
        }
        
        public void UpdateBagShapeByItemCount(int itemCount)
        {
            scalePercentage = scaleCurve.Evaluate((float)itemCount / itemsToMaxScale);
        }
    }
}
