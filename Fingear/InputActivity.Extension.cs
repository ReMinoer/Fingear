using System;

namespace Fingear
{
    static public class InputActivityExtension
    {
        static public bool Is(this InputActivity inputActivity, InputActivity desiredActivity)
        {
            switch (desiredActivity)
            {
                case InputActivity.Idle:
                    return inputActivity.IsIdle();
                case InputActivity.Pressed:
                    return inputActivity.IsPressed();
                case InputActivity.Released:
                    return inputActivity.IsReleased();
                case InputActivity.Triggered:
                    return inputActivity.IsTriggered();
                default:
                    throw new NotSupportedException();
            }
        }

        static public bool IsIdle(this InputActivity inputActivity)
        {
            return (inputActivity & InputActivity.Pressed) != InputActivity.Pressed;
        }

        static public bool IsPressed(this InputActivity inputActivity)
        {
            return (inputActivity & InputActivity.Pressed) == InputActivity.Pressed;
        }

        static public bool IsChanged(this InputActivity inputActivity)
        {
            return (inputActivity & InputActivity.Changed) == InputActivity.Changed;
        }

        static public bool IsReleased(this InputActivity inputActivity)
        {
            return inputActivity == InputActivity.Released;
        }

        static public bool IsTriggered(this InputActivity inputActivity)
        {
            return inputActivity == InputActivity.Triggered;
        }
    }
}