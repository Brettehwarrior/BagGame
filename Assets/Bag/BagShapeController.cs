using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Bag
{
    [ExecuteInEditMode]
    public class BagShapeController : MonoBehaviour
    {
        private const float MaxScale = 5f;
        
        [SerializeField] private Transform targetPointParent;
        [SerializeField] [Range(1f, MaxScale)] private float scale = 1f;
        [SerializeField] [Range(-1f, 1f)] private float xOffset = 0f;
        [SerializeField] private float xOffsetScale = 1f;
        [SerializeField] private SetSplinePositions splinePositionSetter;

        private void Update()
        {
            ScaleTargetPoints();
            OffsetTargetPoints();
        }

        private void ScaleTargetPoints()
        {
            targetPointParent.localScale = Vector3.one * scale;
            splinePositionSetter.TangentScale = scale / MaxScale;
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
    }
}
