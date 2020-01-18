using System;

namespace Fingear
{
    public class InputActivityMachine
    {
        public InputActivity State { get; private set; } = InputActivity.Idle;

        public void Update(InputActivity inputActivity)
        {
            switch (State)
            {
                case InputActivity.Idle:
                    if (inputActivity == InputActivity.Triggered)
                        State = InputActivity.Triggered;
                    break;
                case InputActivity.Triggered:
                    if (inputActivity == InputActivity.Pressed)
                        State = InputActivity.Pressed;
                    else if (inputActivity == InputActivity.Released)
                        State = InputActivity.Released;
                    break;
                case InputActivity.Pressed:
                    if (inputActivity == InputActivity.Released)
                        State = InputActivity.Released;
                    break;
                case InputActivity.Released:
                    if (inputActivity == InputActivity.Idle)
                        State = InputActivity.Idle;
                    else if (inputActivity == InputActivity.Triggered)
                        State = InputActivity.Triggered;
                    break;
                default:
                    throw new NotSupportedException();
            }
        }

        public void Reset()
        {
            State = InputActivity.Idle;
        }
    }
}