using Fingear.Utils;

namespace Fingear.Customizables
{
    public class CustomizableIntensity : CustomizableInput<IIntensityInput>, IIntensityInput
    {
        public float Maximum { get; set; }
        public float Minimum { get; set; }
        public float Delta => Input?.Delta ?? 0f;
        public float Value => Input != null ? MathUtils.ReLerp(Input.Value, Input.Minimum, Input.Maximum, Minimum, Maximum) : 0f;
        public float IdleValue => Input != null ? MathUtils.ReLerp(Input.IdleValue, Input.Minimum, Input.Maximum, Minimum, Maximum) : 0f;
    }
}