using UnityEngine;

namespace Map
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    
    public class LetDestroyer : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private BoxCollider2D _boxCollider;

        private void Awake()
        {
            _boxCollider = GetComponent<BoxCollider2D>();
            _rigidbody = GetComponent<Rigidbody2D>();

            _boxCollider.isTrigger = true;
            _rigidbody.bodyType = RigidbodyType2D.Kinematic;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Let let))
            {
                let.gameObject.SetActive(false);
            }
        }
    }
}