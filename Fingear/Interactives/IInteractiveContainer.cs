using Stave;

namespace Fingear.Interactives
{
    public interface IInteractiveContainer : IContainer<IInteractive, IInteractiveContainer>, IInteractive
    {
    }

    public interface IInteractiveContainer<TComponent> : IContainer<IInteractive, IInteractiveContainer, TComponent>, IInteractiveContainer
        where TComponent : class, IInteractive
    {
    }
}