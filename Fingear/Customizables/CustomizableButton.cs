namespace Fingear.Customizables
{
    public class CustomizableButton : CustomizableInput<IButtonInput>, IButtonInput
    {
        public bool Value => Input?.Value ?? false;
        public bool IdleValue => Input?.IdleValue ?? false;
    }
}