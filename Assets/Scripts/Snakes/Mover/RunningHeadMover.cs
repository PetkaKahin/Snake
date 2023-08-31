using CustomInput;
using UnityEngine;

namespace Snakes
{
    public class RunningHeadMover : BaseHeadMover
    {
        public RunningHeadMover(Transform headSnake, IInput input, float speed) : base(headSnake, input, speed) { }

        public override void Move()
        {
            Head.position += (Vector3.up + new Vector3(Input.Direction.x, 0, 0)) * Speed * Time.deltaTime;
        }
    }
}
