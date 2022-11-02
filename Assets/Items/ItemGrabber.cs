using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public class ItemGrabber : MonoBehaviour
    {
        [SerializeField] private LayerMask itemLayer;
        [SerializeField] private Bounds bounds;
        [SerializeField] private Transform heldItemPosition;

        private IItem _heldItem;

        private void Update()
        {
            CarryItem();
        }

        private void CarryItem()
        {
            if (_heldItem == null)
                return;

            var heldItemTransform = ((MonoBehaviour) _heldItem).transform;
            heldItemTransform.position = heldItemPosition.position;
            heldItemPosition.rotation = heldItemTransform.rotation;
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
            // TODO: Prioritize nearest item
            // Use the bounds to check if there is an item in the area
            var itemCollider = Physics2D.OverlapBox(bounds.center + transform.position, bounds.size, 0f, itemLayer);
            if (itemCollider == null)
                return;
            
            // Pick up item if has IItem behaviour
            _heldItem = itemCollider.GetComponent<IItem>();
            _heldItem?.Pickup();
        }

        private void DropItem()
        {
            _heldItem.Drop();
            _heldItem = null;
        }
        

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(bounds.center + transform.position, bounds.size);
        }
    }
}
