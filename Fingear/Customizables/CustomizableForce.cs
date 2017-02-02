namespace Fingear.Customizables
{
    public class CustomizableForce : CustomizableInput<IForceInput>, IForceInput
    {
    }

    public class CustomizableForce<TValue> : CustomizableInput<IForceInput<TValue>, TValue>, IForceInput<TValue>
    {
        public TValue IdleValue => Input.IdleValue;
    }
}