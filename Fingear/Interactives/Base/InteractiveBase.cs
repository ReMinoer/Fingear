using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Diese;
using Fingear.Controls;
using Stave;
using IComponent = Stave.IComponent;

namespace Fingear.Interactives.Base
{
    public abstract class InteractiveBase : IInteractive, INotifyPropertyChanged
    {
        public string Name { get; set; }
        protected abstract IEnumerable<IControl> ReadOnlyControls { get; }
        IEnumerable<IControl> IInteractive.Controls => ReadOnlyControls;
        
        private bool _enabled = true;
        public bool Enabled
        {
            get => _enabled;
            set
            {
                if (_enabled == value)
                    return;

                _enabled = value;

                if (Enabled)
                    Update(0f);
                else
                    Reset();
            }
        }

        protected InteractiveBase()
        {
            Name = GetType().GetDisplayName();
        }

        public void Update(float elapsedTime)
        {
            if (!Enabled)
                return;

            UpdateEnabled(elapsedTime);
        }

        protected abstract void UpdateEnabled(float elapsedTime);
        public abstract void Reset();

        protected abstract IComponent<IInteractive, IInteractiveContainer> ComponentImplementation { get; }
        
        public IInteractiveContainer Parent
        {
            get => ComponentImplementation.Parent;
            set => ComponentImplementation.Parent = value;
        }
        
        IEnumerable<IInteractive> IComponent<IInteractive>.Components => ComponentImplementation.Components;
        IEnumerable IComponent.Components => ((IComponent)ComponentImplementation).Components;
        IInteractive IComponent<IInteractive>.Parent => ((IComponent<IInteractive>)ComponentImplementation).Parent;
        IComponent IComponent.Parent => ((IComponent)ComponentImplementation).Parent;

        private IComponent ComponentImplementationT0 => ComponentImplementation;
        private IComponent<IInteractive> ComponentImplementationT1 => ComponentImplementation;

        public event Event<IInteractiveContainer> ParentChanged
        {
            add => ComponentImplementation.ParentChanged += value;
            remove => ComponentImplementation.ParentChanged -= value;
        }

        public event Event<IHierarchyChangedEventArgs<IInteractive, IInteractiveContainer>> HierarchyChanged
        {
            add => ComponentImplementation.HierarchyChanged += value;
            remove => ComponentImplementation.HierarchyChanged -= value;
        }

        public event Event<IComponentsChangedEventArgs<IInteractive, IInteractiveContainer>> HierarchyComponentsChanged
        {
            add => ComponentImplementation.HierarchyComponentsChanged += value;
            remove => ComponentImplementation.HierarchyComponentsChanged -= value;
        }

        event Event<IComponent> IComponent.ParentChanged
        {
            add => ComponentImplementationT0.ParentChanged += value;
            remove => ComponentImplementationT0.ParentChanged -= value;
        }

        event Event<IInteractive> IComponent<IInteractive>.ParentChanged
        {
            add => ComponentImplementationT1.ParentChanged += value;
            remove => ComponentImplementationT1.ParentChanged -= value;
        }

        event Event<IHierarchyChangedEventArgs> IComponent.HierarchyChanged
        {
            add => ComponentImplementationT0.HierarchyChanged += value;
            remove => ComponentImplementationT0.HierarchyChanged -= value;
        }

        event Event<IHierarchyChangedEventArgs<IInteractive>> IComponent<IInteractive>.HierarchyChanged
        {
            add => ComponentImplementationT1.HierarchyChanged += value;
            remove => ComponentImplementationT1.HierarchyChanged -= value;
        }

        event Event<IComponentsChangedEventArgs> IComponent.HierarchyComponentsChanged
        {
            add => ComponentImplementationT0.HierarchyComponentsChanged += value;
            remove => ComponentImplementationT0.HierarchyComponentsChanged -= value;
        }

        event Event<IComponentsChangedEventArgs<IInteractive>> IComponent<IInteractive>.HierarchyComponentsChanged
        {
            add => ComponentImplementationT1.HierarchyComponentsChanged += value;
            remove => ComponentImplementationT1.HierarchyComponentsChanged -= value;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}