using System.Collections.Generic;
using Diese;
using Stave;

namespace Fingear.Controls.Base
{
    public abstract class ControlBase : Component<IControl, IControlParent>, IControl
    {
        protected internal bool _isTriggered;
        public string Name { get; set; }
        public abstract IEnumerable<IInputSource> Sources { get; }
        public abstract IEnumerable<IInput> Inputs { get; }

        protected ControlBase()
        {
            Name = GetType().GetDisplayName();
        }

        public void Update(float elapsedTime)
        {
            foreach (IInput input in Inputs)
                input.Update();

            _isTriggered = UpdateControl(elapsedTime);
        }

        protected abstract bool UpdateControl(float elapsedTime);

        public bool IsActive()
        {
            return _isTriggered;
        }
    }

    public abstract class ControlBase<TValue> : ControlBase, IControl<TValue>
    {
        private TValue _value;

        new public void Update(float elapsedTime)
        {
            foreach (IInput input in Inputs)
                input.Update();

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
            return _isTriggered;
        }
    }
}