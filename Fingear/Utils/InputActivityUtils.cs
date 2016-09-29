namespace Fingear.Utils
{
    public class InputActivityUtils
    {
        static public InputActivity UpdatePonctual<TValue>(TValue value, TValue lastValue, TValue idleValue)
        {
            var activity = InputActivity.Idle;

            if (!value.Equals(idleValue))
                activity |= InputActivity.Pressed;
            if (!value.Equals(lastValue))
                activity |= InputActivity.Changed;

            return activity;
        }

        static public InputActivity UpdateContinous<TValue>(TValue value, TValue lastValue, InputActivity lastActivity)
        {
            var inputActivity = InputActivity.Idle;

            if (!value.Equals(lastValue))
                inputActivity |= InputActivity.Pressed;
            if (inputActivity.IsPressed() != lastActivity.IsPressed())
                inputActivity |= InputActivity.Changed;

            return inputActivity;
        }
    }
}