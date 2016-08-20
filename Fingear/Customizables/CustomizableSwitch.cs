namespace Fingear.Customizables
{
    public class CustomizableSwitch : CustomizableInput<ISwitchInput>, ISwitchInput
    {
        public bool Value => Input?.Value ?? false;
    }
}