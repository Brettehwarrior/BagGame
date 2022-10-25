using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

namespace Bag
{
    [ExecuteInEditMode]
    public class SetSplinePositions : MonoBehaviour
    {
        private const float SplineOffset = 0.5f;

        [SerializeField] private SpriteShapeController spriteShapeController;
        [SerializeField] private Transform[] points;

        private void Update()
        {
            // Get center of points
            var center = Vector3.zero;
            foreach (var t in points)
            {
                center += t.localPosition;
            }
            center /= points.Length;
            
            // Set spline node positions
            for (int i = 0; i < points.Length; i++)
            {
                var point = points[i].localPosition;

                try
                {
                    spriteShapeController.spline.SetPosition(i, point);
                }
                catch (ArgumentException e)
                {
                    // Exception caused by spline positions being too close together, offset a bit
                    spriteShapeController.spline.SetPosition(i, point * SplineOffset);
                }

                var towardsCenter = (center - point).normalized;

                var leftTangent = spriteShapeController.spline.GetLeftTangent(i);
                var newRightTangent = Vector2.Perpendicular(towardsCenter) * leftTangent.magnitude;
                var newLeftTangent = -newRightTangent;

                spriteShapeController.spline.SetLeftTangent(i, newLeftTangent);
                spriteShapeController.spline.SetRightTangent(i, newRightTangent);
            }
        }
    }
}