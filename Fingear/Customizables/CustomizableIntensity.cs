using Fingear.Utils;

namespace Fingear.Customizables
{
    public class CustomizableIntensity : CustomizableInput<IIntensityInput, float>, IIntensityInput
    {
        public float Maximum { get; set; }
        public float Minimum { get; set; }
        public float Delta => Input?.Delta ?? 0f;
        public override float Value => Input?.Value.ReLerp(Input.Minimum, Input.Maximum, Minimum, Maximum) ?? 0f;
        public float IdleValue => Input?.IdleValue.ReLerp(Input.Minimum, Input.Maximum, Minimum, Maximum) ?? 0f;
    }
}