using Stave;

namespace Fingear.Controls.Base
{
    public abstract class ControlBase : ComponentBase
    {
        protected override sealed IComponent<IControl, IControlContainer> ComponentImplementation { get; }

        protected ControlBase()
        {
            ComponentImplementation = new Component<IControl, IControlContainer>(this);
        }
    }

    public abstract class ControlBase<TValue> : ControlBase, IControl<TValue>
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