using Fingear.Utils;

namespace Fingear.Customizables
{
    public class CustomizableCursor : CustomizableInput<ICursorInput>, ICursorInput
    {
        public Vector2 Maximum { get; set; }
        public Vector2 Minimum { get; set; }
        public Vector2 Delta => Input?.Delta ?? Vector2.Zero;
        public Vector2 Value => Input?.Value.ReLerp(Input.Minimum, Input.Maximum, Minimum, Maximum) ?? Minimum;
    }
}