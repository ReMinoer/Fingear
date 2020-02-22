using Stave;

namespace Fingear.Controls
{
    public interface IControlContainer : IContainer<IControl, IControlContainer>, IControl
    {
    }

    public interface IControlContainer<TControls> : IControlContainer, IContainer<IControl, IControlContainer, TControls>
        where TControls : class, IControl
    {
    }

    public interface IControlContainer<TControls, TValue> : IControlContainer<TControls>, IControl<TValue>
        where TControls : class, IControl
    {
    }
}