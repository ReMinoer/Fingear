namespace Fingear.Inputs.Base
{
    public abstract class ButtonInputBase : ForceInputBase<bool>, IButtonInput
    {
        public override bool IdleValue => false;
    }
}