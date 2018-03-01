namespace Fingear.Controls.Base
{
    public interface IControlWrapper : IControl
    {
        bool UpdateControl(float elapsedTime);
    }

    public interface IControlWrapper<TValue> : IControlWrapper, IControl<TValue>
    {
        bool UpdateControl(float elapsedTime, out TValue value);
    }
}