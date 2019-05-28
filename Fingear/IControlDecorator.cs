using Stave;

namespace Fingear
{
    public interface IControlDecorator<TComponent> : IDecorator<IControl, IControlContainer, TComponent>, IControlContainer<TComponent>
        where TComponent : class, IControl
    {
    }

    public interface IControlDecorator<TComponent, TValue> : IControlDecorator<TComponent>, IControlContainer<TComponent, TValue>
        where TComponent : class, IControl
    {
    }
}