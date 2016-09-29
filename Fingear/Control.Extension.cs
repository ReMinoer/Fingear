namespace Fingear
{
    static public class ControlExtension
    {
        static public bool Is(this IControl<InputActivity> control, InputActivity desiredActivity)
        {
            InputActivity inputActivity;
            return control.IsActive(out inputActivity) && inputActivity.Is(desiredActivity);
        }

        static public bool IsTriggered(this IControl<InputActivity> control)
        {
            InputActivity inputActivity;
            return control.IsActive(out inputActivity) && inputActivity.IsTriggered();
        }

        static public bool IsReleased(this IControl<InputActivity> control)
        {
            InputActivity inputActivity;
            return control.IsActive(out inputActivity) && inputActivity.IsReleased();
        }

        static public bool IsPressed(this IControl<InputActivity> control)
        {
            InputActivity inputActivity;
            return control.IsActive(out inputActivity) && inputActivity.IsPressed();
        }
    }
}