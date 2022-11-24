using System;
using UnityEngine;

namespace Player
{
    public class RaycastSideChecker : MonoBehaviour
    {
        [SerializeField] private Collider2D environmentCollider;
        [SerializeField] private LayerMask environmentLayer;
        
        [SerializeField] private float verticalCheckSkinWidth = 0.05f;
        [SerializeField] private int verticalCheckRayCount = 20;
        [SerializeField] private float horizontalCheckSkinWidth = 0.05f;
        [SerializeField] private int horizontalCheckRayCount = 20;

        public bool Top { get; private set; }
        public bool Bottom { get; private set; }
        public bool Left { get; private set; }
        public bool Right { get; private set; }

        private void FixedUpdate()
        {
            Top = CheckVertical(Vector2.up);
            Bottom = CheckVertical(Vector2.down);
            Left = CheckHorizontal(Vector2.left);
            Right = CheckHorizontal(Vector2.right);
        }

        /// <summary>
        /// Check for ray collision vertically
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        private bool CheckVertical(Vector2 direction)
        {
            // Get collider bounds
            var bounds = environmentCollider.bounds;
        
            // Cast rays from center of collider to end of collider + skin width
            for (var horizontalOffset = -bounds.extents.x; horizontalOffset <= bounds.extents.x; horizontalOffset += bounds.extents.x * 2 / verticalCheckRayCount)
            {
                var origin = bounds.center + new Vector3(horizontalOffset, (bounds.extents * direction).y, 0);
                var hit = Physics2D.Raycast(origin, direction, verticalCheckSkinWidth, environmentLayer);
            
                // Draw ray
                Debug.DrawRay(origin, direction * verticalCheckSkinWidth, Color.red);
            
                if (hit.collider != null)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Check for ray collision horizontally
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        private bool CheckHorizontal(Vector2 direction)
        {
            // Get collider bounds
            var bounds = environmentCollider.bounds;
            
            // Cast rays from center of collider to end of collider + skin width
            for (var verticalOffset = -bounds.extents.y; verticalOffset <= bounds.extents.y; verticalOffset += bounds.extents.y * 2 / horizontalCheckRayCount)
            {
                var origin = bounds.center + new Vector3((bounds.extents * direction).x, verticalOffset, 0);
                var hit = Physics2D.Raycast(origin, direction, horizontalCheckSkinWidth, environmentLayer);
            
                // Draw ray
                Debug.DrawRay(origin, direction * horizontalCheckSkinWidth, Color.red);
            
                if (hit.collider != null)
                {
                    return true;
                }
            }

            return false;
        }
    }
}