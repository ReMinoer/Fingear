using Stave;

namespace Fingear
{
    public interface IInteractiveContainer : IContainer<IInteractive, IInteractiveContainer>, IInteractive
    {
    }

    public interface IInteractiveContainer<TComponent> : IContainer<IInteractive, IInteractiveContainer, TComponent>, IInteractiveContainer
        where TComponent : class, IInteractive
    {
    }
}