using System.Collections.Generic;
using System.Linq;
using Diese;
using Stave;

namespace Fingear.Controls.Base
{
    public abstract class ControlDecoratorBase<TControl> : Decorator<IControl, IControlParent, TControl>, IControlDecorator<TControl>
        where TControl : class, IControl
    {
        internal bool _isTriggered;
        public string Name { get; set; }
        public virtual IEnumerable<IInputSource> Sources => Component.Sources;
        public virtual IEnumerable<IInput> Inputs => Component.Inputs;
        public bool Handled { get; set; }

        protected ControlDecoratorBase()
        {
            Name = GetType().GetDisplayName();
        }

        public void Update(float elapsedTime)
        {
            Handled = false;

            Component.Update(elapsedTime);

            _isTriggered = UpdateControl(elapsedTime);
        }

        protected abstract bool UpdateControl(float elapsedTime);

        public bool IsActive()
        {
            if (Handled || Inputs.Any(x => x.Handled))
                return false;

            return _isTriggered;
        }

        public void HandleControl()
        {
            Handled = true;
        }

        public void HandleInputs()
        {
            foreach (IInput input in Inputs)
                input.Handle();
        }
    }

    public abstract class ControlDecoratorBase<TControl, TValue> : ControlDecoratorBase<TControl>, IControlDecorator<TControl, TValue>
        where TControl : class, IControl
    {
        private TValue _value;

        new public void Update(float elapsedTime)
        {
            Handled = false;

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

        public bool IsActive(out TValue value)
        {
            value = _value;

            if (Handled || Inputs.Any(x => x.Handled))
                return false;

            return _isTriggered;
        }
    }
}