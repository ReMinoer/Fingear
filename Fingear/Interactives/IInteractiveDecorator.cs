using Stave;

namespace Fingear.Interactives
{
    public interface IInteractiveDecorator<TComponent> : IDecorator<IInteractive, IInteractiveContainer, TComponent>, IInteractiveContainer
        where TComponent : class, IInteractive
    {
    }
}