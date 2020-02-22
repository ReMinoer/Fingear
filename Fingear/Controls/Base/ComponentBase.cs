using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Diese;
using Fingear.Inputs;
using Stave;
using IComponent = Stave.IComponent;

namespace Fingear.Controls.Base
{
    public abstract class ComponentBase : IControl, INotifyPropertyChanged
    {
        public string Name { get; set; }
        public bool IsActive { get; private set; }
        public abstract IEnumerable<IInput> Inputs { get; }

        public IEnumerable<IInput> BaseInputs => Inputs.SelectMany(x => x.BaseInputs);

        protected ComponentBase()
        {
            Name = GetType().GetDisplayName();
        }
        
        public virtual void Update(float elapsedTime)
        {
            IsActive = UpdateControl(elapsedTime);
        }
        
        protected abstract bool UpdateControl(float elapsedTime);

        public virtual void Reset()
        {
            IsActive = false;
        }
        
        protected abstract IComponent<IControl, IControlContainer> ComponentImplementation { get; }

        public IEnumerable<IControl> Components => ComponentImplementation.Components;
        public IControlContainer Parent
        {
            get => ComponentImplementation.Parent;
            set => ComponentImplementation.Parent = value;
        }
        
        IEnumerable IComponent.Components => ComponentImplementation.Components;
        IComponent IComponent.Parent => ComponentImplementation.Parent;
        IControl IComponent<IControl>.Parent => ComponentImplementation.Parent;

        private IComponent ComponentImplementationT0 => ComponentImplementation;
        private IComponent<IControl> ComponentImplementationT1 => ComponentImplementation;
        
        public event Event<IControlContainer> ParentChanged
        {
            add => ComponentImplementation.ParentChanged += value;
            remove => ComponentImplementation.ParentChanged -= value;
        }

        public event Event<IHierarchyChangedEventArgs<IControl, IControlContainer>> HierarchyChanged
        {
            add => ComponentImplementation.HierarchyChanged += value;
            remove => ComponentImplementation.HierarchyChanged -= value;
        }

        public event Event<IHierarchyComponentAddedEventArgs<IControl, IControlContainer>> HierarchyComponentAdded
        {
            add => ComponentImplementation.HierarchyComponentAdded += value;
            remove => ComponentImplementation.HierarchyComponentAdded -= value;
        }

        event Event<IControl> IComponent<IControl>.ParentChanged
        {
            add => ComponentImplementationT1.ParentChanged += value;
            remove => ComponentImplementationT1.ParentChanged -= value;
        }

        event Event<IHierarchyChangedEventArgs<IControl>> IComponent<IControl>.HierarchyChanged
        {
            add => ComponentImplementationT1.HierarchyChanged += value;
            remove => ComponentImplementationT1.HierarchyChanged -= value;
        }

        event Event<IHierarchyComponentAddedEventArgs<IControl>> IComponent<IControl>.HierarchyComponentAdded
        {
            add => ComponentImplementationT1.HierarchyComponentAdded += value;
            remove => ComponentImplementationT1.HierarchyComponentAdded -= value;
        }

        event Event<IComponent> IComponent.ParentChanged
        {
            add => ComponentImplementationT0.ParentChanged += value;
            remove => ComponentImplementationT0.ParentChanged -= value;
        }

        event Event<IHierarchyChangedEventArgs> IComponent.HierarchyChanged
        {
            add => ComponentImplementationT0.HierarchyChanged += value;
            remove => ComponentImplementationT0.HierarchyChanged -= value;
        }

        event Event<IHierarchyComponentAddedEventArgs> IComponent.HierarchyComponentAdded
        {
            add => ComponentImplementationT0.HierarchyComponentAdded += value;
            remove => ComponentImplementationT0.HierarchyComponentAdded -= value;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}