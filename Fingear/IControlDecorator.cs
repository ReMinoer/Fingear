using Stave;

namespace Fingear
{
    public interface IControlDecorator<TComponent> : IDecorator<IControl, IControlContainer, TComponent>, IControlContainer
        where TComponent : class, IControl
    {
    }

    public interface IControlDecorator<TComponent, TValue> : IControlDecorator<TComponent>, IControlContainer<TValue>
        where TComponent : class, IControl
    {
    }
}