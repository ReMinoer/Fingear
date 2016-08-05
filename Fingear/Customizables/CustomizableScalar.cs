using Fingear.Customizables.Base;

namespace Fingear.Customizables
{
    public class CustomizableScale : CustomizableInputBase<IScaleInput>, IScaleInput
    {
        public float Maximum { get; set; }
        public float Minimum { get; set; }
        public float Value => Input != null ? Minimum + (Maximum - Minimum) * ((Input.Value - Input.Minimum) / (Input.Maximum - Input.Minimum)) : 0f;
    }
}