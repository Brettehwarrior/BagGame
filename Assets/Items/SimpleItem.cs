using UnityEngine;

namespace Items
{
    public class SimpleItem : MonoBehaviour, IItem
    {
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Pickup()
        {
            _rigidbody.isKinematic = true;
        }

        public void Drop()
        {
            _rigidbody.isKinematic = false;
        }

        public void Launch(Vector2 direction, float force)
        {
            Drop();
            _rigidbody.AddForce(direction * force, ForceMode2D.Impulse);
        }
    }
}
