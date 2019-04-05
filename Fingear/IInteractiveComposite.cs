using Stave;

namespace Fingear
{
    public interface IInteractiveComposite<TComponent> : IComposite<IInteractive, IInteractiveContainer, TComponent>, IInteractiveContainer
        where TComponent : class, IInteractive
    {
    }
}