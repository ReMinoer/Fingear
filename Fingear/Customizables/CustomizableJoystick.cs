using Fingear.Customizables.Base;

namespace Fingear.Customizables
{
    public class CustomizableJoystick : CustomizableInputBase<IJoystickInput>, IJoystickInput
    {
        public Vector2 Maximum { get; set; }
        public Vector2 Minimum { get; set; }
        public Vector2 Value => Input != null ? Minimum + (Maximum - Minimum) * ((Input.Value - Input.Minimum) / (Input.Maximum - Input.Minimum)) : Vector2.Zero;
        public Vector2 IdleValue => Input != null ? Minimum + (Maximum - Minimum) * ((Input.IdleValue - Input.Minimum) / (Input.Maximum - Input.Minimum)) : Vector2.Zero;
    }
}