namespace Fingear.Controls.Base
{
    internal interface IControlWrapper : IControl
    {
        bool UpdateControl(float elapsedTime);
    }

    internal interface IControlWrapper<TValue> : IControlWrapper, IControl<TValue>
    {
        bool UpdateControl(float elapsedTime, out TValue value);
    }
}