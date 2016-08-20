namespace Fingear.Customizables
{
    public class CustomizablePonctual : CustomizableInput<IPunctualInput>, IPunctualInput
    {
    }

    public class CustomizablePonctual<TValue> : CustomizableInput<IPunctualInput<TValue>, TValue>, IPunctualInput<TValue>
    {
        public TValue IdleValue => Input.IdleValue;
    }
}