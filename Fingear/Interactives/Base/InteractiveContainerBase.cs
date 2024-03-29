﻿using System.Collections.Generic;
using System.Linq;
using Fingear.Controls;
using Stave;

namespace Fingear.Interactives.Base
{
    public abstract class InteractiveContainerBase<TComponent> : InteractiveBase, IInteractiveContainer<TComponent>
        where TComponent : class, IInteractive
    {
        protected abstract IContainer<IInteractive, IInteractiveContainer, TComponent> ContainerImplementation { get; }
        protected override sealed IComponent<IInteractive, IInteractiveContainer> ComponentImplementation => ContainerImplementation;

        protected override IEnumerable<IControl> ReadOnlyControls => Enumerable.Empty<IControl>();

        protected override void UpdateEnabled(float elapsedTime)
        {
            foreach (TComponent interactive in ContainerImplementation.Components)
                interactive.Update(elapsedTime);
        }

        public override void Reset()
        {
            foreach (TComponent interactive in ContainerImplementation.Components)
                interactive.Reset();
        }

        bool IContainer.Opened => ContainerImplementation.Opened;
        IEnumerable<TComponent> IContainer<IInteractive, IInteractiveContainer, TComponent>.Components => ContainerImplementation.Components;
        void IContainer<IInteractive>.Link(IInteractive child) => ContainerImplementation.Link(child);
        void IContainer<IInteractive>.Unlink(IInteractive child) => ContainerImplementation.Unlink(child);
        bool IContainer<IInteractive>.TryLink(IInteractive child) => ContainerImplementation.TryLink(child);
        bool IContainer<IInteractive>.TryUnlink(IInteractive child) => ContainerImplementation.TryUnlink(child);
        void IContainer<IInteractive, IInteractiveContainer, TComponent>.Link(TComponent child) => ContainerImplementation.Link(child);
        void IContainer<IInteractive, IInteractiveContainer, TComponent>.Unlink(TComponent child) => ContainerImplementation.Unlink(child);
        bool IContainer<IInteractive, IInteractiveContainer, TComponent>.TryLink(TComponent child) => ContainerImplementation.TryLink(child);
        bool IContainer<IInteractive, IInteractiveContainer, TComponent>.TryUnlink(TComponent child) => ContainerImplementation.TryUnlink(child);

        private IContainer ContainerImplementationT0 => ContainerImplementation;
        private IContainer<IInteractive> ContainerImplementationT1 => ContainerImplementation;
        protected IContainer<IInteractive, IInteractiveContainer> ContainerImplementationT2 => ContainerImplementation;

        public event Event<IComponentsChangedEventArgs<IInteractive, IInteractiveContainer, TComponent>> ComponentsChanged
        {
            add => ContainerImplementation.ComponentsChanged += value;
            remove => ContainerImplementation.ComponentsChanged -= value;
        }

        event Event<IComponentsChangedEventArgs> IContainer.ComponentsChanged
        {
            add => ContainerImplementationT0.ComponentsChanged += value;
            remove => ContainerImplementationT0.ComponentsChanged -= value;
        }

        event Event<IComponentsChangedEventArgs<IInteractive>> IContainer<IInteractive>.ComponentsChanged
        {
            add => ContainerImplementationT1.ComponentsChanged += value;
            remove => ContainerImplementationT1.ComponentsChanged -= value;
        }

        event Event<IComponentsChangedEventArgs<IInteractive, IInteractiveContainer>> IContainer<IInteractive, IInteractiveContainer>.ComponentsChanged
        {
            add => ContainerImplementationT2.ComponentsChanged += value;
            remove => ContainerImplementationT2.ComponentsChanged -= value;
        }
    }
}