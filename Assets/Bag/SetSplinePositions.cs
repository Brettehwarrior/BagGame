using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SetSplinePositions : MonoBehaviour
{
    [SerializeField] private SpriteShapeController spriteShapeController;
    [SerializeField] private Transform[] points;
    
    private void Update()
    {
        for (int i = 0; i < points.Length; i++)
        {
            var point = points[i].localPosition;
            spriteShapeController.spline.SetPosition(i, point);
            
            var towardsCenter = (Vector3.zero - point).normalized;
            var rightTangent = Vector2.Perpendicular(towardsCenter);
            var leftTangent = -rightTangent;
            
            spriteShapeController.spline.SetRightTangent(i, rightTangent * spriteShapeController.spline.GetRightTangent(i));
            spriteShapeController.spline.SetLeftTangent(i, leftTangent * spriteShapeController.spline.GetLeftTangent(i));
        }
    }
}
