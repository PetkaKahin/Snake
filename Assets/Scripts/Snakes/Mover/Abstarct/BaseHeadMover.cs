using CustomInput;
using UnityEngine;
using System;

namespace Snakes
{
    public abstract class BaseHeadMover
    {
        protected readonly Transform Head;

        protected float Speed;

        protected IInput Input;

        public BaseHeadMover(Transform headSnake, IInput input, float speed)
        {
            Head = headSnake;
            Input = input;
            Speed = speed;
        }

        public abstract void Move();

        public virtual void SetSpeed(float speed)
        {
            if (speed < 0)
                throw new ArgumentOutOfRangeException(nameof(speed));

            Speed = speed;
        }

        public virtual void SetInput(IInput input)
        {
            Input = input;
        }
    }
}
