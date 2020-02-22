using Stave;

namespace Fingear.Interactives
{
    public interface IInteractiveComposite<TComponent> : IComposite<IInteractive, IInteractiveContainer, TComponent>, IInteractiveContainer
        where TComponent : class, IInteractive
    {
    }
}