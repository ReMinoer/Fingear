using Fingear.Utils;

namespace Fingear.Customizables
{
    public class CustomizableJoystick : CustomizableInput<IJoystickInput>, IJoystickInput
    {
        public Vector2 Maximum { get; set; }
        public Vector2 Minimum { get; set; }
        public Vector2 Delta => Input?.Delta ?? Vector2.Zero;
        public Vector2 Value => Input != null ? MathUtils.ReLerp(Input.Value, Input.Minimum, Input.Maximum, Minimum, Maximum) : Vector2.Zero;
        public Vector2 IdleValue => Input != null ? MathUtils.ReLerp(Input.IdleValue, Input.Minimum, Input.Maximum, Minimum, Maximum) : Vector2.Zero;
    }
}