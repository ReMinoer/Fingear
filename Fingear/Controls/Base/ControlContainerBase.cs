using System.Collections.Generic;
using System.Linq;
using Diese;
using Stave;

namespace Fingear.Controls.Base
{
    public abstract class ControlContainerBase<TControls> : Container<IControl, IControlParent, TControls>, IControlContainer<TControls>
        where TControls : class, IControl
    {
        internal bool _isTriggered;
        public string Name { get; set; }
        public IEnumerable<IInputSource> Sources { get; protected set; }
        public virtual IEnumerable<IInput> Inputs => Components.SelectMany(x => x.Inputs);
        public bool Handled { get; set; }

        protected ControlContainerBase()
        {
            Name = GetType().GetDisplayName();
        }

        public void Update(float elapsedTime)
        {
            Handled = false;

            foreach (TControls control in Components)
                control.Update(elapsedTime);

            _isTriggered = UpdateControl(elapsedTime);
        }

        protected abstract bool UpdateControl(float elapsedTime);

        public bool IsActive()
        {
            if (Handled || InputManager.Instance.HandledInputs.Count != 0 && Inputs.Any(x => x.Handler != null && x.Handler != this))
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
                input.HandleBy(this);
        }
    }

    public abstract class ControlContainerBase<TControls, TValue> : ControlContainerBase<TControls>, IControlContainer<TControls, TValue>
        where TControls : class, IControl
    {
        private TValue _value;

        new public void Update(float elapsedTime)
        {
            Handled = false;

            foreach (TControls control in Components)
                control.Update(elapsedTime);

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
            return IsActive();
        }
    }
}