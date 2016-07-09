namespace Fingear
{
    public interface IInputDevice
    {
        IInputSource InputSource { get; }
    }

    public interface IInputDevice<out TValue>
    {
        TValue Value { get; }
    }
}