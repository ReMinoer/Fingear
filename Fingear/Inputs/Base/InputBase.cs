using System;

namespace Fingear.Inputs.Base
{
    public abstract class InputBase<TValue> : IInput<TValue>
        where TValue : IEquatable<TValue>
    {
        private TValue _value;
        public abstract string DisplayName { get; }
        public InputActivity Activity { get; private set; }
        public abstract TValue Value { get; }
        public abstract IInputSource Source { get; }
        public bool Updated { get; private set; }
        public bool Handled { get; internal set; }
        protected TValue LastValue { get; private set; }

        protected InputBase()
        {
            InputManager.Instance.Register(this);
        }

        public void Prepare()
        {
            Updated = false;
        }

        public virtual void Update()
        {
            if (Updated)
                return;

            Handled = false;
            LastValue = _value;
            _value = Value;
            Activity = UpdateActivity(_value);
            Updated = true;
        }

        protected abstract InputActivity UpdateActivity(TValue value);

        public void Handle()
        {
            InputManager.Instance.Handle(this);
        }
    }
}