using System;
using System.Collections.Generic;
using UnityEngine;

namespace Bag.Shape
{
    public class FollowObjectsCenter : MonoBehaviour
    {
        [SerializeField] private List<Transform> points;

        private void FixedUpdate()
        {
            var bounds = new Bounds(points[0].position, Vector3.zero);

            for (var i = 1; i < points.Count; i++)
            {
                bounds.Encapsulate(points[i].position);
            }

            transform.position = bounds.center;
        }
    }
}