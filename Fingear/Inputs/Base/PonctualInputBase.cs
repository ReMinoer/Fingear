using System;
using Fingear.Utils;

namespace Fingear.Inputs.Base
{
    public abstract class PonctualInputBase<TValue> : IPunctualInput<TValue>
        where TValue : IEquatable<TValue>
    {
        public abstract string DisplayName { get; }
        public InputActivity Activity { get; private set; }
        public abstract TValue Value { get; }
        public abstract TValue IdleValue { get; }
        public abstract IInputSource Source { get; }
        protected TValue LastValue { get; private set; }

        public virtual void Update()
        {
            TValue value = Value;
            Activity = InputActivityUtils.UpdatePonctual(value, LastValue, IdleValue);
            LastValue = value;
        }
    }
}