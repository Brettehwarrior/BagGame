using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

namespace Items
{
    public class ItemGrabber : MonoBehaviour
    {
        [SerializeField] private LayerMask itemLayer;
        [SerializeField] private Bounds bounds;
        [SerializeField] private Transform heldItemPosition;

        public IItem _heldItem { get; private set; }

        public Transform HeldItemStash()
        {
            Transform heldItemTransform = null;
            if (_heldItem != null)
            {
                heldItemTransform = heldItemPosition.GetChild(0);
                DropItem();
            }
            return heldItemTransform;
        }

        public void TryPickUpDropItem()
        {
            if (_heldItem != null)
                DropItem();
            else
                PickUpItem();
        }

        private void PickUpItem()
        {
            // Use the bounds to check if there is an item in the area and get nearest
            var colliders = Physics2D.OverlapBoxAll(bounds.center + transform.position, bounds.size, 0f, itemLayer);
            Collider2D itemCollider = null;
            var minDistance = float.MaxValue;
            foreach (var col in colliders)
            {
                if (itemCollider == null || Vector2.Distance(transform.position, col.transform.position) < minDistance)
                {
                    itemCollider = col;
                    minDistance = Vector2.Distance(transform.position, col.transform.position);
                }
            }
            
            if (itemCollider == null)
                return;
            
            // Pick up item if has IItem behaviour
            _heldItem = itemCollider.GetComponent<IItem>();
            _heldItem?.Pickup();
            
            // Set the item's parent to this object
            var itemTransform = itemCollider.transform;
            itemTransform.SetParent(heldItemPosition);
            itemTransform.localPosition = Vector3.zero;
        }

        private void DropItem()
        {
            _heldItem.Drop();
            ((MonoBehaviour) _heldItem).transform.SetParent(transform.parent);
            _heldItem = null;
        }
        

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(bounds.center + transform.position, bounds.size);
        }
    }
}

