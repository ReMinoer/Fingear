using System.Collections.Generic;
using System.Linq;
using Stave;

namespace Fingear.Controls.Base
{
    public abstract class ControlCompositeBase<TControls> : Composite<IControl, IControlParent, TControls>, IControlComposite<TControls>
        where TControls : class, IControl
    {
        protected internal bool _isTriggered;
        public IEnumerable<IInputSource> Sources { get; protected set; }
        public virtual IEnumerable<IInput> Inputs => Components.SelectMany(x => x.Inputs);

        public void Update(float elapsedTime)
        {
            foreach (IInput input in Inputs)
                input.Update();

            foreach (TControls control in Components)
                control.Update(elapsedTime);

            _isTriggered = UpdateControl(elapsedTime);
        }

        protected abstract bool UpdateControl(float elapsedTime);

        public bool IsTriggered()
        {
            return _isTriggered;
        }
    }

    public abstract class ControlCompositeBase<TControls, TValue> : ControlCompositeBase<TControls>, IControlComposite<TControls, TValue>
        where TControls : class, IControl
    {
        private TValue _value;

        new public void Update(float elapsedTime)
        {
            foreach (IInput input in Inputs)
                input.Update();

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

        public bool IsTriggered(out TValue value)
        {
            value = _value;
            return _isTriggered;
        }
    }
}