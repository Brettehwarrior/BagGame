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

        private Transform _heldItem;

        private void Update()
        {
            CarryItem();
        }

        private void CarryItem()
        {
            if (_heldItem == null)
                return;
            
            _heldItem.position = heldItemPosition.position;
            heldItemPosition.rotation = _heldItem.rotation;
        }

        public void TryPickUpItem()
        {
            // Use the bounds to check if there is an item in the area
            var itemCollider = Physics2D.OverlapBox(bounds.center + transform.position, bounds.size, 0f, itemLayer);
            if (itemCollider == null)
                return;
            Debug.Log(itemCollider);
            
            // Check if the collider is an item
            var item = itemCollider.GetComponent<IItem>();
            if (item == null)
                return;
            
            item.Pickup();
            
            // Get transform of the item
            _heldItem = ((MonoBehaviour) item).transform;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(bounds.center + transform.position, bounds.size);
        }
    }
}
