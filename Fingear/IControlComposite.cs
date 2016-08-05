using Stave;

namespace Fingear
{
    public interface IControlComposite<TControls> : IComposite<IControl, IControlParent, TControls>, IControlParent
        where TControls : class, IControl
    {
    }

    public interface IControlComposite<TControls, TValue> : IControlComposite<TControls>, IControlParent<TValue>
        where TControls : class, IControl
    {
    }
}