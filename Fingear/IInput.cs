using System.Numerics;

namespace Fingear
{
    public interface IInput
    {
        string DisplayName { get; }
        InputActivity Activity { get; }
        IInputSource Source { get; }
        bool Updated { get; }
        void Prepare();
        void Update();
        void Reset();
    }

    public interface IInput<out TValue> : IInput
    {
        TValue Value { get; }
    }

    public interface IForceInput : IInput
    {
    }

    public interface IForceInput<out TValue> : IForceInput, IInput<TValue>
    {
        TValue IdleValue { get; }
    }

    public interface IPositionInput : IInput
    {
    }

    public interface IPositionInput<out TValue> : IPositionInput, IInput<TValue>
    {
    }

    public interface IBooleanInput : IInput<bool>
    {
    }

    public interface IScalarInput : IInput<float>
    {
        float Maximum { get; }
        float Minimum { get; }
        float Delta { get; }
    }

    public interface IVectorInput : IInput<Vector2>
    {
        Vector2 Maximum { get; }
        Vector2 Minimum { get; }
        Vector2 Delta { get; }
    }

    public interface IButtonInput : IBooleanInput, IForceInput<bool>
    {
    }

    public interface ISwitchInput : IBooleanInput, IPositionInput<bool>
    {
    }

    public interface IIntensityInput : IScalarInput, IForceInput<float>
    {
    }

    public interface IScaleInput : IScalarInput, IPositionInput<float>
    {
    }

    public interface IJoystickInput : IVectorInput, IForceInput<Vector2>
    {
    }

    public interface ICursorInput : IVectorInput, IPositionInput<Vector2>
    {
    }
}