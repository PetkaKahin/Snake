using CustomInput;
using UnityEngine;

namespace Snakes
{
    public class ClassicHeadMover : BaseHeadMover
    {
        public ClassicHeadMover(Transform headSnake, IInput input, float speed) : base(headSnake, input, speed) { }

        public override void Move()
        {
            Head.position += (Vector3)Input.Direction * Speed * Time.deltaTime;
        }
    }
}
