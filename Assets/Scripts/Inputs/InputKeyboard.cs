using UnityEngine;

namespace CustomInput
{
    public class InputKeyboard : IInput
    {
        public Vector2 Direction => GetInput();

        private Vector2 GetInput()
        {
            Vector2 input = new Vector2();

            if (Input.GetKey(KeyCode.W))
                input += new Vector2(0, 1);

            if (Input.GetKey(KeyCode.S))
                input += new Vector2(0, -1);

            if (Input.GetKey(KeyCode.A))
                input += new Vector2(-1, 0);

            if (Input.GetKey(KeyCode.D))
                input += new Vector2(1, 0);

            return input;
        }
    }
}
