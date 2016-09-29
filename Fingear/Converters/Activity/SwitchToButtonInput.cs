using Fingear.Inputs.Base;

namespace Fingear.Converters.Activity
{
    public class SwitchToButtonInput : PonctualInputBase<bool>, IButtonInput
    {
        public ISwitchInput SwitchInput { get; set; }
        public override string DisplayName => SwitchInput?.DisplayName ?? "";
        public override bool Value => SwitchInput?.Activity.IsChanged() ?? false;
        public override bool IdleValue => false;
        public override IInputSource Source => SwitchInput?.Source;

        public SwitchToButtonInput()
        {
        }

        public SwitchToButtonInput(ISwitchInput switchInput)
        {
            SwitchInput = switchInput;
        }
    }
}