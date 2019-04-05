using Stave;

namespace Fingear
{
    public interface IInteractiveDecorator<TComponent> : IDecorator<IInteractive, IInteractiveContainer, TComponent>, IInteractiveContainer
        where TComponent : class, IInteractive
    {
    }
}