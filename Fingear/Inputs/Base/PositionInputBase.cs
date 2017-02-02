using System;
using Fingear.Utils;

namespace Fingear.Inputs.Base
{
    public abstract class PositionInputBase<TValue> : IPositionInput<TValue>
        where TValue : IEquatable<TValue>
    {
        private TValue _value;
        public abstract string DisplayName { get; }
        public InputActivity Activity { get; private set; }
        public abstract TValue Value { get; }
        public abstract IInputSource Source { get; }
        protected TValue LastValue { get; private set; }

        public virtual void Update()
        {
            LastValue = _value;
            _value = Value;
            Activity = InputActivityUtils.UpdateContinous(_value, LastValue, Activity);
        }
    }
}