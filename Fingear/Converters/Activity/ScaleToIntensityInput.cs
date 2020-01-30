using System.Collections.Generic;
using Fingear.Inputs.Base;
using Fingear.Utils;

namespace Fingear.Converters.Activity
{
    public class ScaleToIntensityInput : ForceInputBase<float>, IIntensityInput
    {
        public IScaleInput ScaleInput { get; set; }
        public float DeltaMin { get; }
        public float DeltaMax { get; }

        public override string DisplayName => ScaleInput?.DisplayName ?? "";
        public override float Value => ScaleInput?.Delta.Clamp(DeltaMin, DeltaMax).ReLerp(DeltaMin, DeltaMax, Minimum, Maximum) ?? 0f;
        public override float IdleValue => 0;
        public override IInputSource Source => ScaleInput?.Source;
        public float Maximum => 1;
        public float Minimum => -1;
        public float Delta => Value - LastValue;

        protected override IEnumerable<IInput> BaseInputs
        {
            get { yield return ScaleInput; }
        }
        
        public ScaleToIntensityInput(float deltaMin = -1, float deltaMax = 1)
        {
            DeltaMin = deltaMin;
            DeltaMax = deltaMax;
        }

        public ScaleToIntensityInput(IScaleInput scaleInput, float deltaMin = -1, float deltaMax = 1)
            : this(deltaMin, deltaMax)
        {
            ScaleInput = scaleInput;
            DeltaMin = deltaMin;
            DeltaMax = deltaMax;
        }

        public override void Update()
        {
            ScaleInput?.Update();
            base.Update();
        }
    }
}