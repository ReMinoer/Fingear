using Stave;

namespace Fingear
{
    public interface IControlComposite<TControls> : IComposite<IControl, IControlContainer, TControls>, IControlContainer
        where TControls : class, IControl
    {
    }

    public interface IControlComposite<TControls, TValue> : IControlComposite<TControls>, IControlContainer<TValue>
        where TControls : class, IControl
    {
    }
}