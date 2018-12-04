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

        static public bool Not(this InputActivity inputActivity, InputActivity desiredActivity) => !inputActivity.Is(desiredActivity);
        static public bool NotIdle(this InputActivity inputActivity) => !inputActivity.IsIdle();
        static public bool NotPressed(this InputActivity inputActivity) => !inputActivity.IsPressed();
        static public bool NotChanged(this InputActivity inputActivity) => !inputActivity.IsChanged();
        static public bool NotReleased(this InputActivity inputActivity) => !inputActivity.IsReleased();
        static public bool NotTriggered(this InputActivity inputActivity) => !inputActivity.IsTriggered();
    }
}