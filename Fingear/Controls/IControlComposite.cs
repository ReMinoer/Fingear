using Stave;

namespace Fingear.Controls
{
    public interface IControlComposite<TControls> : IComposite<IControl, IControlContainer, TControls>, IControlContainer<TControls>
        where TControls : class, IControl
    {
    }

    public interface IControlComposite<TControls, TValue> : IControlComposite<TControls>, IControlContainer<TControls, TValue>
        where TControls : class, IControl
    {
    }
}