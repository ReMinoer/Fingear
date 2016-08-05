using Fingear.Customizables.Base;

namespace Fingear.Customizables
{
    public class CustomizableCursor : CustomizableInputBase<ICursorInput>, ICursorInput
    {
        public Vector2 Maximum { get; set; }
        public Vector2 Minimum { get; set; }
        public Vector2 Value => Input != null ? Minimum + (Maximum - Minimum) * ((Input.Value - Input.Minimum) / (Input.Maximum - Input.Minimum)) : Minimum;
    }
}