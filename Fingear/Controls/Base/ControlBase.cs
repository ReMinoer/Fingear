using System.Collections.Generic;
using System.Linq;
using Diese;
using Stave;

namespace Fingear.Controls.Base
{
    public abstract class ControlBase : Component<IControl, IControlParent>, IControl
    {
        internal bool _isTriggered;
        public string Name { get; set; }
        public abstract IEnumerable<IInputSource> Sources { get; }
        public abstract IEnumerable<IInput> Inputs { get; }
        public bool Handled { get; internal set; }

        protected ControlBase()
        {
            Name = GetType().GetDisplayName();
        }

        public void Update(float elapsedTime)
        {
            Handled = false;
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

    public abstract class ControlBase<TValue> : ControlBase, IControl<TValue>
    {
        private TValue _value;

        new public void Update(float elapsedTime)
        {
            Handled = false;

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