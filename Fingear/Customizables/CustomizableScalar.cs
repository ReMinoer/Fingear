using Fingear.Utils;

namespace Fingear.Customizables
{
    public class CustomizableScale : CustomizableInput<IScaleInput>, IScaleInput
    {
        public float Maximum { get; set; }
        public float Minimum { get; set; }
        public float Delta => Input?.Delta ?? 0f;
        public float Value => Input?.Value.ReLerp(Input.Minimum, Input.Maximum, Minimum, Maximum) ?? 0f;
    }
}