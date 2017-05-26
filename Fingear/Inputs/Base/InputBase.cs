using System;
using Fingear.Utils;

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
        public bool Handled { get; private set; }
        protected TValue LastValue { get; private set; }

        public virtual void Update()
        {
            Handled = false;
            LastValue = _value;
            _value = Value;
            Activity = UpdateActivity(_value);
        }

        protected abstract InputActivity UpdateActivity(TValue value);

        public void Handle()
        {
            Handled = true;
        }
    }
}