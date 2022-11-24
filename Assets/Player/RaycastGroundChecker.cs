using System;
using UnityEngine;

namespace Player
{
    public class RaycastGroundChecker : MonoBehaviour
    {
        [SerializeField] private Collider2D environmentCollider;
        [SerializeField] private LayerMask environmentLayer;
        
        [SerializeField] private float groundCheckSkinWidth = 0.05f;
        [SerializeField] private int groundCheckRayCount = 20;
        
        public bool IsGrounded { get; private set; }

        private void FixedUpdate()
        {
            CheckGrounded();
        }

        private void CheckGrounded()
        {
            // Get collider bounds
            var bounds = environmentCollider.bounds;
        
            // Cast rays from center of collider to bottom of collider + skin width
            for (var horizontalOffset = -bounds.extents.x; horizontalOffset <= bounds.extents.x; horizontalOffset += bounds.extents.x * 2 / groundCheckRayCount)
            {
                var origin = bounds.center + new Vector3(horizontalOffset, -bounds.extents.y, 0);
                var hit = Physics2D.Raycast(origin, Vector2.down, groundCheckSkinWidth, environmentLayer);
            
                // Draw ray
                Debug.DrawRay(origin, Vector2.down * groundCheckSkinWidth, Color.red);
            
                if (hit.collider != null)
                {
                    IsGrounded = true;
                    return;
                }
            }
        
            IsGrounded = false;
        }
    }
}