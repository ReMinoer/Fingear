namespace Fingear.Customizables
{
    public class CustomizableButton : CustomizableInput<IButtonInput, bool>, IButtonInput
    {
        public bool IdleValue => Input?.IdleValue ?? false;
    }
}