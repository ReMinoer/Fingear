using Diese.Collections.Observables.ReadOnly;
using Stave;

namespace Fingear.Controls.Base
{
    public abstract class ControlCompositeBase<TControls> : ContainerBase<TControls>, IControlComposite<TControls>
        where TControls : class, IControl
    {
        private readonly Composite<IControl, IControlContainer, TControls> _compositeImplementation;
        protected override IContainer<IControl, IControlContainer, TControls> ContainerImplementation => _compositeImplementation;

        protected ControlCompositeBase()
        {
            _compositeImplementation = new Composite<IControl, IControlContainer, TControls>(this);
        }
        
        new public IWrappedObservableCollection<TControls> Components => _compositeImplementation.Components;
        public void Add(TControls item) => _compositeImplementation.Add(item);
        public bool Remove(TControls item) => _compositeImplementation.Remove(item);
        public void Clear() => _compositeImplementation.Clear();
        public bool Contains(TControls item) => _compositeImplementation.Contains(item);
    }

    public abstract class ControlCompositeBase<TControls, TValue> : ControlCompositeBase<TControls>, IControlComposite<TControls, TValue>
        where TControls : class, IControl
    {
        private TValue _value;

        public bool IsActive(out TValue value)
        {
            value = _value;
            return base.IsActive;
        }

        protected override sealed bool UpdateControl(float elapsedTime)
        {
            bool isActive = UpdateControlValue(elapsedTime, out TValue value);
            _value = value;
            return isActive;
        }

        protected abstract bool UpdateControlValue(float elapsedTime, out TValue value);

        public override void Reset()
        {
            _value = default(TValue);
            base.Reset();
        }
    }
}