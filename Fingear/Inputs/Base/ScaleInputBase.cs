namespace Fingear.Inputs.Base
{
    public abstract class ScaleInputBase : PositionInputBase<float>, IScaleInput
    {
        public abstract float Maximum { get; }
        public abstract float Minimum { get; }
        public float Delta => Value - LastValue;
    }
}