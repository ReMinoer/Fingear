using Fingear.Inputs.Base;
using Fingear.Utils;

namespace Fingear.Converters.Activity
{
    public class ScaleToIntensityInput : PonctualInputBase<float>, IIntensityInput
    {
        public IScaleInput ScaleInput { get; set; }
        public override string DisplayName => ScaleInput?.DisplayName ?? "";
        public override float Value => ScaleInput?.Delta.Normalized() ?? 0f;
        public override float IdleValue => 0;
        public override IInputSource Source => ScaleInput?.Source;
        public float Maximum => 1;
        public float Minimum => -1;
        public float Delta => Value - LastValue;

        public ScaleToIntensityInput()
        {
        }

        public ScaleToIntensityInput(IScaleInput scaleInput)
        {
            ScaleInput = scaleInput;
        }
    }
}