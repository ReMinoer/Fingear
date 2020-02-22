namespace Fingear.Inputs.Customizables
{
    public class CustomizablePosition : CustomizableInput<IPositionInput>, IPositionInput
    {
    }

    public class CustomizablePosition<TValue> : CustomizableInput<IPositionInput<TValue>, TValue>, IPositionInput<TValue>
    {
    }
}