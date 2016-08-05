using Fingear.Customizables.Base;

namespace Fingear.Customizables
{
    public class CustomizableButton : CustomizableInputBase<IButtonInput>, IButtonInput
    {
        public bool Value => Input?.Value ?? false;
        public bool IdleValue => Input?.IdleValue ?? false;
    }
}