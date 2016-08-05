using Fingear.Inputs.Base;

namespace Fingear.Inputs
{
    public abstract class ScaleInputBase : ContinousInputBase<float>, IScaleInput
    {
        public abstract float Maximum { get; }
        public abstract float Minimum { get; }
    }
}