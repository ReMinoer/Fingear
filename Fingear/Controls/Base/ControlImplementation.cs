using System.Linq;
using Diese;

namespace Fingear.Controls.Base
{
    internal class ControlImplementation
    {
        private readonly IControlWrapper _wrapper;
        protected bool IsTriggered;
        public string Name { get; set; }
        public bool Handled { get; protected set; }

        public ControlImplementation(IControlWrapper wrapper)
        {
            _wrapper = wrapper;
            Name = GetType().GetDisplayName();
        }

        public virtual void Update(float elapsedTime)
        {
            Handled = false;
            IsTriggered = _wrapper.UpdateControl(elapsedTime);
        }

        public bool IsActive()
        {
            if (Handled || InputManager.Instance.HandledInputs.Count != 0 && _wrapper.Inputs.Any(x => x.Handler != null && x.Handler != _wrapper))
                return false;

            return IsTriggered;
        }

        public void HandleControl()
        {
            Handled = true;
        }

        public void HandleInputs()
        {
            foreach (IInput input in _wrapper.Inputs)
                input.HandleBy(_wrapper);
        }
    }

    internal class ControlImplementation<TValue> : ControlImplementation
    {
        private readonly IControlWrapper<TValue> _wrapper;
        private TValue _value;

        public ControlImplementation(IControlWrapper<TValue> wrapper)
            : base(wrapper)
        {
            _wrapper = wrapper;
        }

        public override void Update(float elapsedTime)
        {
            Handled = false;
            IsTriggered = _wrapper.UpdateControl(elapsedTime, out _value);
        }

        public bool IsActive(out TValue value)
        {
            value = _value;
            return IsActive();
        }
    }
}