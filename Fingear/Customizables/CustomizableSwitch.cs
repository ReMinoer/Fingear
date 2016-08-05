using Fingear.Customizables.Base;

namespace Fingear.Customizables
{
    public class CustomizableSwitch : CustomizableInputBase<ISwitchInput>, ISwitchInput
    {
        public bool Value => Input?.Value ?? false;
    }
}