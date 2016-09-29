using Fingear.Inputs.Base;

namespace Fingear.Converters.Activity
{
    public class CursorToJoystickInput : PonctualInputBase<Vector2>, IJoystickInput
    {
        public ICursorInput CursorInput { get; set; }
        public override string DisplayName => CursorInput?.DisplayName ?? "";
        public override Vector2 Value => CursorInput?.Delta.Normalized ?? Vector2.Zero;
        public override Vector2 IdleValue => Vector2.Zero;
        public override IInputSource Source => CursorInput?.Source;
        public Vector2 Maximum => Vector2.One;
        public Vector2 Minimum => -Vector2.One;
        public Vector2 Delta => Value - LastValue;

        public CursorToJoystickInput()
        {
        }

        public CursorToJoystickInput(ICursorInput cursorInput)
        {
            CursorInput = cursorInput;
        }
    }
}