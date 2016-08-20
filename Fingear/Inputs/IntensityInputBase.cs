using Fingear.Inputs.Base;

namespace Fingear.Inputs
{
    public abstract class IntensityInputBase : PonctualInputBase<float>, IIntensityInput
    {
        public abstract float Maximum { get; }
        public abstract float Minimum { get; }
        public float Delta => Value - LastValue;
    }
}