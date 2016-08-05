using Fingear.Inputs.Base;

namespace Fingear.Inputs
{
    public abstract class ButtonInputBase : PonctualInputBase<bool>, IButtonInput
    {
        public override bool IdleValue => false;
    }
}