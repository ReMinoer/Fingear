using System;
using Fingear.Utils;

namespace Fingear.Inputs.Base
{
    public abstract class ForceInputBase<TValue> : IForceInput<TValue>
        where TValue : IEquatable<TValue>
    {
        private TValue _value;
        public abstract string DisplayName { get; }
        public InputActivity Activity { get; private set; }
        public abstract TValue Value { get; }
        public abstract TValue IdleValue { get; }
        public abstract IInputSource Source { get; }
        public bool Handled { get; private set; }
        protected TValue LastValue { get; private set; }

        public virtual void Update()
        {
            Handled = false;
            LastValue = _value;
            _value = Value;
            Activity = InputActivityUtils.UpdatePonctual(_value, LastValue, IdleValue);
        }

        public void Handle()
        {
            Handled = true;
        }
    }
}