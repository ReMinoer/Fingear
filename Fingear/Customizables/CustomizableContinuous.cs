namespace Fingear.Customizables
{
    public class CustomizableContinuous : CustomizableInput<IContinuousInput>, IContinuousInput
    {
    }

    public class CustomizableContinuous<TValue> : CustomizableInput<IContinuousInput<TValue>, TValue>, IContinuousInput<TValue>
    {
    }
}