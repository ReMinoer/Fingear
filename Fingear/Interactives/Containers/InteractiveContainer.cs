using Fingear.Interactives.Base;
using Stave;
using Stave.Base;

namespace Fingear.Interactives.Containers
{
    public class InteractiveContainer : InteractiveContainer<IInteractive>
    {
    }

    public class InteractiveContainer<TComponent> : InteractiveContainerBase<TComponent>
        where TComponent : class, IInteractive
    {
        private readonly SealedOrderedComposite<IInteractive, IInteractiveContainer, TComponent> _composite;
        protected override sealed IContainer<IInteractive, IInteractiveContainer, TComponent> ContainerImplementation => _composite;
        
        protected ComponentList<IInteractive, IInteractiveContainer, TComponent> Components => _composite.Components;

        protected InteractiveContainer()
        {
            _composite = new SealedOrderedComposite<IInteractive, IInteractiveContainer, TComponent>(this);
        }
    }
}