using Fingear.Inputs.Base;

namespace Fingear.Inputs
{
    public abstract class ButtonInputBase : ForceInputBase<bool>, IButtonInput
    {
        public override bool IdleValue => false;
    }
}