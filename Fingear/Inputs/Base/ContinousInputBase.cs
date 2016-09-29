using System;
using Fingear.Utils;

namespace Fingear.Inputs.Base
{
    public abstract class ContinousInputBase<TValue> : IContinuousInput<TValue>
        where TValue : IEquatable<TValue>
    {
        public abstract string DisplayName { get; }
        public InputActivity Activity { get; private set; }
        public abstract TValue Value { get; }
        public abstract IInputSource Source { get; }
        protected TValue LastValue { get; private set; }

        public virtual void Update()
        {
            TValue value = Value;
            Activity = InputActivityUtils.UpdateContinous(value, LastValue, Activity);
            LastValue = value;
        }
    }
}