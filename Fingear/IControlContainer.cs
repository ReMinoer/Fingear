using Stave;

namespace Fingear
{
    public interface IControlContainer : IContainer<IControl, IControlContainer>, IControl
    {
    }

    public interface IControlContainer<TValue> : IControlContainer, IControl<TValue>
    {
    }
}