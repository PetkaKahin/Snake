using Health;
using Snakes;
using UnityEngine;

namespace Map
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Let : MonoBehaviour
    {
        private const int Damage = 1;

        [SerializeField] private int _startValue;

        private BoxCollider2D _boxCollider;

        private IHealth _health;

        private void Awake()
        {
            _boxCollider = GetComponent<BoxCollider2D>();
            _boxCollider.isTrigger = true;
            _health = new BaseHeath(_startValue);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Snake snake))
            {
                MakeDamage(snake.Health);
                _health.TakeDamage(Damage);
            }
        }

        private void MakeDamage(IHealth health)
        {
            health.TakeDamage(Damage);
        }

        private void OnEnable()
        {
            _health.Died += Die;
        }

        private void OnDisable()
        {
            _health.Died -= Die;
        }

        private void Die()
        {
            gameObject.SetActive(false);
        }
    }
}