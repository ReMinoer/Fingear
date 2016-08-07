using System.Collections.Generic;
using Stave;

namespace Fingear.Controls.Base
{
    public abstract class ControlDecoratorBase<TControl> : Decorator<IControl, IControlParent, TControl>, IControlDecorator<TControl>
        where TControl : class, IControl
    {
        protected internal bool _isTriggered;
        public IEnumerable<IInputSource> Sources { get; protected set; }
        public virtual IEnumerable<IInput> Inputs => Component.Inputs;

        public void Update(float elapsedTime)
        {
            foreach (IInput input in Inputs)
                input.Update();

            Component.Update(elapsedTime);

            _isTriggered = UpdateControl(elapsedTime);
        }

        protected abstract bool UpdateControl(float elapsedTime);

        public bool IsTriggered()
        {
            return _isTriggered;
        }
    }

    public abstract class ControlDecoratorBase<TControl, TValue> : ControlDecoratorBase<TControl>, IControlDecorator<TControl, TValue>
        where TControl : class, IControl
    {
        private TValue _value;

        new public void Update(float elapsedTime)
        {
            foreach (IInput input in Inputs)
                input.Update();

            Component.Update(elapsedTime);

            TValue value;
            _isTriggered = UpdateControl(elapsedTime, out value);
            _value = value;
        }

        protected override sealed bool UpdateControl(float elapsedTime)
        {
            TValue value;
            return UpdateControl(elapsedTime, out value);
        }

        protected abstract bool UpdateControl(float elapsedTime, out TValue value);

        public bool IsTriggered(out TValue value)
        {
            value = _value;
            return _isTriggered;
        }
    }
}