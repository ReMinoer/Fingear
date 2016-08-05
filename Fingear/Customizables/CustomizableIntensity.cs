using Fingear.Customizables.Base;

namespace Fingear.Customizables
{
    public class CustomizableIntensity : CustomizableInputBase<IIntensityInput>, IIntensityInput
    {
        public float Maximum { get; set; }
        public float Minimum { get; set; }
        public float Value => Input != null ? Minimum + (Maximum - Minimum) * ((Input.Value - Input.Minimum) / (Input.Maximum - Input.Minimum)) : 0f;
        public float IdleValue => Input != null ? Minimum + (Maximum - Minimum) * ((Input.IdleValue - Input.Minimum) / (Input.Maximum - Input.Minimum)) : 0f;
    }
}