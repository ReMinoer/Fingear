namespace Fingear
{
    public interface ICustomizableInput : IInput
    {
        IInput Input { get; }
    }

    public interface ICustomizableInput<TInput> : ICustomizableInput
    {
        new TInput Input { get; set; }
    }

    public interface ICustomizableInput<TInput, out TValue> : ICustomizableInput<TInput>, IInput<TValue>
    {
    }
}