using Stave;

namespace Fingear.Controls.Base
{
    public abstract class ControlDecoratorBase<TControl> : ContainerBase<TControl>, IControlDecorator<TControl>
        where TControl : class, IControl
    {
        private readonly Decorator<IControl, IControlContainer, TControl> _decoratorImplementation;
        protected override IContainer<IControl, IControlContainer, TControl> ContainerImplementation => _decoratorImplementation;

        protected ControlDecoratorBase()
        {
            _decoratorImplementation = new Decorator<IControl, IControlContainer, TControl>(this);
        }

        public TControl Component
        {
            get => _decoratorImplementation.Component;
            set => _decoratorImplementation.Component = value;
        }

        public TControl Unlink() => _decoratorImplementation.Unlink();
    }

    public abstract class ControlDecoratorBase<TControl, TValue> : ControlDecoratorBase<TControl>, IControlDecorator<TControl, TValue>
        where TControl : class, IControl
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
            _value = isActive ? value : default(TValue);
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