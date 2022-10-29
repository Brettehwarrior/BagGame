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
        [SerializeField] [Range(0f, 1f)] private float tangentScale = 1f;
        [SerializeField] private Transform[] points;
        
        public float TangentScale
        {
            get => tangentScale;
            set => tangentScale = value;
        }
        public Transform[] Points => points;
        
        private void Update()
        {
            UpdateSpline();
        }

        public void UpdateSpline()
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
                    Debug.Log("Caught ArgumentException: " + e.Message);
                    spriteShapeController.spline.SetPosition(i, point * SplineOffset);
                }

                var towardsCenter = (center - point).normalized;

                var newRightTangent = Vector2.Perpendicular(towardsCenter) * tangentScale;
                var newLeftTangent = -newRightTangent;

                spriteShapeController.spline.SetLeftTangent(i, newLeftTangent);
                spriteShapeController.spline.SetRightTangent(i, newRightTangent);
            }
        }
    }
}