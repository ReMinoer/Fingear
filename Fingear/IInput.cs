namespace Fingear
{
    public interface IInput
    {
        InputActivity Activity { get; }
        IInputSource Source { get; }
        void Update();
    }

    public interface IInput<out TValue> : IInput
    {
        TValue Value { get; }
    }

    public interface IPunctualInput : IInput
    {
    }

    public interface IPunctualInput<out TValue> : IPunctualInput, IInput<TValue>
    {
        TValue IdleValue { get; }
    }

    public interface IContinuousInput : IInput
    {
    }

    public interface IContinuousInput<out TValue> : IContinuousInput, IInput<TValue>
    {
    }

    public interface IBooleanInput : IInput<bool>
    {
    }

    public interface IScalarInput : IInput<float>
    {
        float Maximum { get; }
        float Minimum { get; }
    }

    public interface IVectorInput : IInput<Vector2>
    {
        Vector2 Maximum { get; }
        Vector2 Minimum { get; }
    }

    public interface IButtonInput : IBooleanInput, IPunctualInput<bool>
    {
    }

    public interface ISwitchInput : IBooleanInput, IContinuousInput<bool>
    {
    }

    public interface IIntensityInput : IScalarInput, IPunctualInput<float>
    {
    }

    public interface IScaleInput : IScalarInput, IContinuousInput<float>
    {
    }

    public interface IJoystickInput : IVectorInput, IPunctualInput<Vector2>
    {
    }

    public interface ICursorInput : IVectorInput, IContinuousInput<Vector2>
    {
    }
}