namespace Fingear.Inputs.Base
{
    public abstract class IntensityInputBase : ForceInputBase<float>, IIntensityInput
    {
        public abstract float Maximum { get; }
        public abstract float Minimum { get; }
        public float Delta => Value - LastValue;
    }
}