using System;

namespace Health
{
    public class BaseHeath : IHealth
    {
        private int _maxHeath;
        private int _health;

        public event Action Changed;
        public event Action Died;

        public int Value => _health;

        public BaseHeath(int health)
        {
            _health = health;
            _maxHeath = health;
        }

        public void Heal(int value)
        {
            IsValueMoreZero(value);
            _health += value;

            if (_health > _maxHeath)
                _health = _maxHeath;

            Changed?.Invoke();
        }

        public void TakeDamage(int value)
        {
            IsValueMoreZero(value);
            _health -= value;

            if (_health <= 0)
                Died?.Invoke();

            Changed?.Invoke();
        }

        public void IncreaseMaxHealth(int value)
        {
            IsValueMoreZero(value);
            _maxHeath += value;
        }

        public void DecreaseMaxHealth(int value)
        {
            IsValueMoreZero(value);
            _maxHeath -= value;
        }

        private void IsValueMoreZero(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));
        }
    }
}
