using System;

namespace Health
{
    public interface IHealth
    {
        int Value { get; }

        event Action Changed;
        event Action Died;

        void TakeDamage(int value);
        void Heal(int value);
        void IncreaseMaxHealth(int value);
        void DecreaseMaxHealth(int value);
    }
}