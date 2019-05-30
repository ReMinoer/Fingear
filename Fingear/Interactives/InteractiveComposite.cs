﻿using Diese.Collections;
using Fingear.Interactives.Base;
using Stave;

namespace Fingear.Interactives
{
    public class InteractiveComposite : InteractiveComposite<IInteractive>
    {
    }

    public class InteractiveComposite<TComponent> : InteractiveContainerBase<TComponent>, IInteractiveComposite<TComponent>
        where TComponent : class, IInteractive
    {
        protected virtual IComposite<IInteractive, IInteractiveContainer, TComponent> CompositeImplementation { get; }
        protected override sealed IContainer<IInteractive, IInteractiveContainer, TComponent> ContainerImplementation => CompositeImplementation;

        protected InteractiveComposite()
        {
            CompositeImplementation = new Composite<IInteractive, IInteractiveContainer, TComponent>(this);
        }

        public IWrappedCollection<TComponent> Components => CompositeImplementation.Components;
        public void Add(TComponent item) => CompositeImplementation.Add(item);
        public bool Remove(TComponent item) => CompositeImplementation.Remove(item);
        public void Clear() => CompositeImplementation.Clear();
        public bool Contains(TComponent item) => CompositeImplementation.Contains(item);
    }
}