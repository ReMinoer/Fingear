using Stave;

namespace Fingear
{
    public interface IControlDecorator<TComponent> : IDecorator<IControl, IControlParent, TComponent>, IControlParent
        where TComponent : class, IControl
    {
    }

    public interface IControlDecorator<TComponent, TValue> : IControlDecorator<TComponent>, IControlParent<TValue>
        where TComponent : class, IControl
    {
    }
}