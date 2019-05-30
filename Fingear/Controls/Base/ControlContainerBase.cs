using Stave;
using Stave.Base;

namespace Fingear.Controls.Base
{
    public abstract class ControlContainerBase<TControls> : ContainerBase<TControls>
        where TControls : class, IControl
    {
        private readonly SealedOrderedComposite<IControl, IControlContainer, TControls> _containerImplementation;
        protected override sealed IContainer<IControl, IControlContainer, TControls> ContainerImplementation => _containerImplementation;

        protected ControlContainerBase()
        {
            _containerImplementation = new SealedOrderedComposite<IControl, IControlContainer, TControls>(this);
        }

        new protected ComponentList<IControl, IControlContainer, TControls> Components => _containerImplementation.Components;
    }

    public abstract class ControlContainerBase<TControls, TValue> : ControlContainerBase<TControls>, IControlContainer<TControls, TValue>
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