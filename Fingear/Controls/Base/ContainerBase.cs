using System.Collections.Generic;
using System.Linq;
using Stave;

namespace Fingear.Controls.Base
{
    public abstract class ContainerBase<TControls> : ComponentBase, IControlContainer<TControls>
        where TControls : class, IControl
    {
        public override IEnumerable<IInput> Inputs => Components.SelectMany(x => x.Inputs);

        public override void Update(float elapsedTime)
        {
            foreach (TControls control in Components)
                control.Update(elapsedTime);

            base.Update(elapsedTime);
        }

        public override void Reset()
        {
            foreach (TControls control in Components)
                control.Reset();

            base.Reset();
        }

        protected abstract IContainer<IControl, IControlContainer, TControls> ContainerImplementation { get; }
        protected override sealed IComponent<IControl, IControlContainer> ComponentImplementation => ContainerImplementation;
        
        new public IEnumerable<TControls> Components => ContainerImplementation.Components;
        public bool Opened => ContainerImplementation.Opened;

        public void Link(IControl child) => ContainerImplementation.Link(child);
        public void Unlink(IControl child) => ContainerImplementation.Unlink(child);
        public bool TryLink(IControl child) => ContainerImplementation.TryLink(child);
        public bool TryUnlink(IControl child) => ContainerImplementation.TryUnlink(child);
        public void Link(TControls child) => ContainerImplementation.Link(child);
        public void Unlink(TControls child) => ContainerImplementation.Unlink(child);
        public bool TryLink(TControls child) => ContainerImplementation.TryLink(child);
        public bool TryUnlink(TControls child) => ContainerImplementation.TryUnlink(child);

        protected IContainer ContainerImplementationT0 => ContainerImplementation;
        protected IContainer<IControl> ContainerImplementationT1 => ContainerImplementation;

        public event Event<TControls> ComponentAdded
        {
            add => ContainerImplementation.ComponentAdded += value;
            remove => ContainerImplementation.ComponentAdded -= value;
        }

        event Event<IControl> IContainer<IControl>.ComponentAdded
        {
            add => ContainerImplementationT1.ComponentAdded += value;
            remove => ContainerImplementationT1.ComponentAdded -= value;
        }

        event Event<IComponent> IContainer.ComponentAdded
        {
            add => ContainerImplementationT0.ComponentAdded += value;
            remove => ContainerImplementationT0.ComponentAdded -= value;
        }
    }
}