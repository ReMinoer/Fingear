namespace Fingear.Inputs.Customizables
{
    public interface ICustomizableInput : IInput
    {
        IInput Input { get; }
    }

    public interface ICustomizableInput<TInput> : ICustomizableInput
        where TInput : IInput
    {
        new TInput Input { get; set; }
    }

    public interface ICustomizableInput<TInput, out TValue> : ICustomizableInput<TInput>, IInput<TValue>
        where TInput : IInput<TValue>
    {
    }
}